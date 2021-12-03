using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Business.Service
{
    public class InternalTransferService : IInternalTransferService
    {
        private readonly InternalTransferValidator _validator;
        private readonly InternalTransferMapper _mapper;
        private readonly IInternalTransferRepositoryFactory _internalTransferRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly IInternalTransferServiceFactory _internalTransferIntegrationServiceFactory;
        private readonly ISubAccountRepositoryFactory _subAccountRepositoryFactory;
        private readonly IFavoredRepositoryFactory _favoredRepositoryFactory;
        private readonly Settings _settings;
        private readonly IOperationRepositoryFactory _operationRepositoryFactory;
        private readonly IOperationTagRepositoryFactory _operationTagRepositoryFactory;
        private IConnectionFactory _connectionFactory;


        public InternalTransferService(
            IInternalTransferRepositoryFactory internalTransferRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IOperationRepositoryFactory operationRepositoryFactory,
            IOperationTagRepositoryFactory operationTagRepositoryFactory,
            IInternalTransferServiceFactory internalTransferIntegrationServiceFactory,
            ISubAccountRepositoryFactory subAccountRepositoryFactory,
            IFavoredRepositoryFactory favoredRepositoryFactory,
            Settings settings,
            IConnectionFactory connectionFactory
        )
        {
            _internalTransferRepositoryFactory = internalTransferRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _internalTransferIntegrationServiceFactory = internalTransferIntegrationServiceFactory;
            _subAccountRepositoryFactory = subAccountRepositoryFactory;
            _favoredRepositoryFactory = favoredRepositoryFactory;
            _operationRepositoryFactory = operationRepositoryFactory;
            _operationTagRepositoryFactory = operationTagRepositoryFactory;
            _mapper = new InternalTransferMapper();
            _validator = new InternalTransferValidator();
            _settings = settings;
            _connectionFactory = connectionFactory;
        }

        public void Save(InternalTransferRequest internalTransferRequest)
        {
            _validator.Validate(internalTransferRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                Account fromAccount = accountRepository.GetById(internalTransferRequest.AccountId);
                if (fromAccount == null)
                    throw new OsbBusinessException(BusinessExcMsg.EXC0009);

                Account toAccount;

                if (string.IsNullOrEmpty(internalTransferRequest.AccountKey))
                    toAccount = accountRepository.GetByTaxId(internalTransferRequest.ToTaxId,
                                                                    internalTransferRequest.Bank,
                                                                    internalTransferRequest.BankBranch,
                                                                    internalTransferRequest.BankAccount,
                                                                    internalTransferRequest.BankAccountDigit);
                else
                    toAccount = accountRepository.GetByAccountKey(internalTransferRequest.AccountKey);

                if (toAccount == null)
                    throw new OsbBusinessException(BusinessExcMsg.EXC0010);

                IFavoredRepository favoredRepository = _favoredRepositoryFactory.Create();
                IEnumerable<Favored> favoreds = favoredRepository.GetFavored(fromAccount.AccountId, toAccount.TaxId,
                                                                                internalTransferRequest.Bank,
                                                                                internalTransferRequest.BankBranch,
                                                                                internalTransferRequest.BankAccount,
                                                                                OperationType.InternalTransfer
                );

                if (favoreds.GetEnumerator().MoveNext() == false)
                {
                    Favored favored = Favored.Create(fromAccount.AccountId, toAccount.TaxId, toAccount.Name,
                                                        OperationType.InternalTransfer, null,
                                                        toAccount.Bank, toAccount.BankBranch,
                                                        toAccount.BankAccount, toAccount.BankAccountDigit
                    );
                    favoredRepository.Save(favored, transactionScope);
                }

                Operation operation = Operation.Create(internalTransferRequest.UserId);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
                foreach (string tag in internalTransferRequest.Tags)
                {
                    OperationTag operationTag = OperationTag.Create(operation.OperationId, tag, internalTransferRequest.UserId);
                    operationTagRepository.Save(operationTag, transactionScope);
                }

                InternalTransfer internalTransfer = InternalTransfer.Create(fromAccount.AccountId,
                                                                            toAccount.AccountId,
                                                                            internalTransferRequest.TransferValue,
                                                                            internalTransferRequest.TransferDate,
                                                                            internalTransferRequest.Description,
                                                                            operation.OperationId,
                                                                            internalTransferRequest.UserId);

                IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
                internalTransferRepository.Save(internalTransfer, transactionScope);

                transactionScope.Transaction.Commit();
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public void GenerateInternalTransfer(long internalTransferId)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
            InternalTransfer internalTransfer = internalTransferRepository.GetById(internalTransferId);

            IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
            IEnumerable<OperationTag> operationTags = operationTagRepository.GetOperationTagsByOperationId(internalTransfer.OperationId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account fromAccount = accountRepository.GetById(internalTransfer.FromAccountId);
            Account toAccount = accountRepository.GetById(internalTransfer.ToAccountId);

            IntegrationRequest.InternalTransferRequest integrationRequest = _mapper.Map(fromAccount, toAccount, internalTransfer, operationTags);

            IntegrationService.IInternalTransferService internalTransferIntergrationService = _internalTransferIntegrationServiceFactory.Create();
            IntegrationResponse.InternalTransferResponse internalTransferResponse = internalTransferIntergrationService.InternalTransfer(integrationRequest);

            if (internalTransferResponse.ExternalIdentifier > 0)
            {
                internalTransferRepository.UpdateStatus(internalTransfer.InternalTransferId,
                                                        internalTransferResponse.ExternalIdentifier,
                                                        InternalTransferStatus.Generated);
            }
            else
            {
                if (internalTransfer.Attempts <= _settings.Attempts)
                    internalTransferRepository.UpdateAttempts(internalTransfer.InternalTransferId);
                else
                    internalTransferRepository.UpdateStatus(internalTransfer.Identifier,
                                                            InternalTransferStatus.Error);
            }
        }

        public void CancelInternalTransfer(CancelInternalTransferRequest cancelInternalTransferRequest)
        {

            _validator.Validate(cancelInternalTransferRequest);

            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
            InternalTransfer internalTransfer = internalTransferRepository.GetByExternalIdentifier(cancelInternalTransferRequest.ExternalIdentifier.Value);

            if (internalTransfer == null)
                throw new OsbBusinessException(BusinessExcMsg.EXC0050);

            if (internalTransfer.Status != InternalTransferStatus.Generated && internalTransfer.Status != InternalTransferStatus.Created)
                throw new OsbBusinessException(BusinessExcMsg.EXC0049);

            internalTransfer.Status = InternalTransferStatus.PreCanceled;
            internalTransfer.UpdateUserId = cancelInternalTransferRequest.UserId;

            internalTransferRepository.Update(internalTransfer);
        }

        public void CancelInternalTransfer(long internalTransferId)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
            InternalTransfer internalTransfer = internalTransferRepository.GetById(internalTransferId);

            IntegrationRequest.CancelInternalTransferRequest integrationRequest = _mapper.Map(internalTransfer);

            IntegrationService.IInternalTransferService internalTransferIntergrationService = _internalTransferIntegrationServiceFactory.Create();
            bool cancelInternalTransferResponse = internalTransferIntergrationService.CancelInternalTransfer(integrationRequest);

            if (cancelInternalTransferResponse)
                internalTransfer.Status = InternalTransferStatus.Canceled;
            else
            {
                if (internalTransfer.Attempts <= _settings.Attempts)
                    internalTransferRepository.UpdateAttempts(internalTransfer.InternalTransferId);
                else
                    internalTransfer.Status = InternalTransferStatus.Error;
            }

            internalTransferRepository.Update(internalTransfer);
        }

        public IEnumerable<InternalTransfer> FindInternalTransferListByStatus(InternalTransferStatus status)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
            IEnumerable<InternalTransfer> internalTransferList = internalTransferRepository.GetByStatus(status);

            return internalTransferList;
        }

        public void UpdateInternalTransferStatus(UpdateInternalTransferStatusRequest updateInternalTransferStatusRequest)
        {
            _validator.Validate(updateInternalTransferStatusRequest);

            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
            internalTransferRepository.UpdateStatus(updateInternalTransferStatusRequest.Identifier,
                                                    updateInternalTransferStatusRequest.Status);
        }

        public void UpdateInternalTransferAttempts(long internalTransferId)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
            internalTransferRepository.UpdateAttempts(internalTransferId);
        }

        public void UpdateStatus(UpdateInternalTransferRequest updateInternalTransferRequest)
        {
            _validator.Validate(updateInternalTransferRequest);

            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
            InternalTransfer internalTransfer = internalTransferRepository.GetById(updateInternalTransferRequest.InternalTransferId.Value);

            internalTransfer.Status = updateInternalTransferRequest.Status;
            internalTransfer.UpdateUserId = updateInternalTransferRequest.UserId;

            internalTransferRepository.Update(internalTransfer);
        }

        public FindPendingInternalTransferResult FindPendingInternalTransfer(FindPendingInternalTransferRequest findPendingInternalTransferRequest)
        {
            _validator.Validate(findPendingInternalTransferRequest);

            IntegrationRequest.FindPendingInternalTransferRequest integrationRequest = _mapper.Map(findPendingInternalTransferRequest);

            IntegrationService.IInternalTransferService internalTransferIntegrationService = _internalTransferIntegrationServiceFactory.Create();
            IntegrationResponse.FindPendingInternalTransferResponse findPendingInternalTransferResponse = internalTransferIntegrationService.FindPendingInternalTransfer(integrationRequest);

            FindPendingInternalTransferResult result = _mapper.Map(findPendingInternalTransferResponse);
            return result;
        }
    }
}