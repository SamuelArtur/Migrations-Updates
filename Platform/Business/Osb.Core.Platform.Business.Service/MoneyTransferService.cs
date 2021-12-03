using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Business.Service
{
    public class MoneyTransferService : IMoneyTransferService
    {
        private readonly MoneyTransferValidator _validator;
        private readonly MoneyTransferMapper _mapper;
        private readonly IMoneyTransferServiceFactory _moneyTransferIntegrationServiceFactory;
        private readonly IMoneyTransferRepositoryFactory _moneyTransferRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly IBankingDataRepositoryFactory _bankingDataRepositoryFactory;
        private IConnectionFactory _connectionFactory;
        private readonly Settings _settings;

        public MoneyTransferService(
            IMoneyTransferServiceFactory moneyTransferIntegrationServiceFactory,
            IMoneyTransferRepositoryFactory moneyTransferRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IBankingDataRepositoryFactory bankingDataRepositoryFactory,
            Settings settings,
            IConnectionFactory connectionFactory
        )
        {
            _moneyTransferIntegrationServiceFactory = moneyTransferIntegrationServiceFactory;
            _moneyTransferRepositoryFactory = moneyTransferRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _bankingDataRepositoryFactory = bankingDataRepositoryFactory;
            _mapper = new MoneyTransferMapper();
            _validator = new MoneyTransferValidator();
            _settings = settings;
            _connectionFactory = connectionFactory;
        }

        public void Save(MoneyTransferRequest insertMoneyTransferRequest)
        {
            _validator.Validate(insertMoneyTransferRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                BankingData bankingData = BankingData.Create(
                    insertMoneyTransferRequest.Bank,
                    insertMoneyTransferRequest.BankBranch,
                    insertMoneyTransferRequest.BankAccount,
                    insertMoneyTransferRequest.BankAccountDigit
                );

                IBankingDataRepository bankingDataRepository = _bankingDataRepositoryFactory.Create();
                BankingData bankingDataResult = bankingDataRepository.Save(bankingData, transactionScope);

                MoneyTransfer moneyTransfer = MoneyTransfer.Create(
                    insertMoneyTransferRequest.AccountId,
                    insertMoneyTransferRequest.ToTaxId,
                    insertMoneyTransferRequest.ToName,
                    bankingDataResult.BankingDataId,
                    insertMoneyTransferRequest.Value,
                    insertMoneyTransferRequest.TransferDate,
                    MoneyTransferStatus.Created,
                    insertMoneyTransferRequest.Description
                );

                IMoneyTransferRepository moneyTransferRepository = _moneyTransferRepositoryFactory.Create();
                MoneyTransfer moneyTransferResult = moneyTransferRepository.Save(moneyTransfer, transactionScope);

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

        public void GenerateMoneyTransfer(MoneyTransfer moneyTransfer)
        {
            IBankingDataRepository bankingDataRepository = _bankingDataRepositoryFactory.Create();
            BankingData bankingData = bankingDataRepository.GetById(moneyTransfer.BankingDataId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(moneyTransfer.FromAccountId);

            IMoneyTransferRepository moneyTransferRepository = _moneyTransferRepositoryFactory.Create();
            IntegrationRequest.MoneyTransferRequest integrationRequest = _mapper.Map(moneyTransfer, account, bankingData);

            IntegrationService.IMoneyTransferService moneyTransferIntergrationService = _moneyTransferIntegrationServiceFactory.Create();
            IntegrationResponse.MoneyTransferResponse moneyTransferResponse = moneyTransferIntergrationService.MoneyTransfer(integrationRequest);

            if (moneyTransferResponse.ExternalIdentifier > 0)
            {
                moneyTransfer.ExternalIdentifier = moneyTransferResponse.ExternalIdentifier.ToString();
                moneyTransfer.Status = MoneyTransferStatus.Generated;
                moneyTransferRepository.Update(moneyTransfer);
            }
            else
            {
                if (moneyTransfer.Attempts <= _settings.Attempts)
                    moneyTransferRepository.UpdateAttempts(moneyTransfer.MoneyTransferId);
                else
                {
                    moneyTransfer.Status = MoneyTransferStatus.Error;
                    moneyTransferRepository.Update(moneyTransfer);
                }
            }
        }

        public FindExpectedTransferDateResult FindExpectedTransferDate(FindExpectedTransferDateRequest findExpectedTransferDateRequest)
        {
            _validator.Validate(findExpectedTransferDateRequest);

            IntegrationRequest.FindExpectedTransferDateRequest integrationRequest = _mapper.Map(
                findExpectedTransferDateRequest
            );
            IntegrationService.IMoneyTransferService moneyTransferIntergrationService = _moneyTransferIntegrationServiceFactory.Create();
            IntegrationResponse.FindExpectedTransferDateResponse findExpectedTransferDateResponse = moneyTransferIntergrationService.FindExpectedTransferDate(integrationRequest);

            FindExpectedTransferDateResult result = _mapper.Map(findExpectedTransferDateResponse);
            return result;
        }

        public IEnumerable<MoneyTransfer> FindMoneyTransferListByStatus(MoneyTransferStatus status)
        {
            IMoneyTransferRepository moneyTransferRepository = _moneyTransferRepositoryFactory.Create();
            IEnumerable<MoneyTransfer> moneyTransferList = moneyTransferRepository.GetByStatus(status);
            return moneyTransferList;
        }

        public void UpdateMoneyTransferStatus(UpdateMoneyTransferStatusRequest updateMoneyTransferStatusRequest)
        {
            _validator.Validate(updateMoneyTransferStatusRequest);

            IMoneyTransferRepository moneyTransferRepository = _moneyTransferRepositoryFactory.Create();
            MoneyTransfer moneyTransfer = moneyTransferRepository.GetByIdentifier(updateMoneyTransferStatusRequest.Identifier);

            moneyTransfer.Status = updateMoneyTransferStatusRequest.Status;
            moneyTransferRepository.Update(moneyTransfer);
        }

        public void UpdateMoneyTransferAttempts(long moneyTransferId)
        {
            IMoneyTransferRepository moneyTransferRepository = _moneyTransferRepositoryFactory.Create();
            moneyTransferRepository.UpdateAttempts(moneyTransferId);
        }

        public void Update(UpdateMoneyTransferRequest updateMoneyTransferRequest)
        {
            _validator.Validate(updateMoneyTransferRequest);

            IMoneyTransferRepository moneyTransferRepository = _moneyTransferRepositoryFactory.Create();
            MoneyTransfer moneyTransfer = moneyTransferRepository.GetById(updateMoneyTransferRequest.MoneyTransferId.Value);

            moneyTransfer.Status = updateMoneyTransferRequest.Status;
            moneyTransfer.UpdateUserId = updateMoneyTransferRequest.UserId;

            moneyTransferRepository.Update(moneyTransfer);
        }

        public void CancelMoneyTransfer(CancelMoneyTransferRequest cancelMoneyTransferRequest)
        {
            _validator.Validate(cancelMoneyTransferRequest);

            IMoneyTransferRepository moneyTransferRepository = _moneyTransferRepositoryFactory.Create();
            MoneyTransfer moneyTransfer = moneyTransferRepository.GetByExternalIdentifier(cancelMoneyTransferRequest.ExternalIdentifier);

            if (moneyTransfer.Status != MoneyTransferStatus.Generated)
                throw new OsbBusinessException(BusinessExcMsg.EXC0012);

            moneyTransfer.Status = MoneyTransferStatus.PreCanceled;
            moneyTransfer.UpdateUserId = cancelMoneyTransferRequest.UserId;

            moneyTransferRepository.Update(moneyTransfer);
        }

        public void CancelMoneyTransfer(MoneyTransfer moneyTransfer)
        {
            IMoneyTransferRepository moneyTransferRepository = _moneyTransferRepositoryFactory.Create();

            IntegrationRequest.CancelMoneyTransferRequest integrationRequest = _mapper.Map(moneyTransfer);

            IntegrationService.IMoneyTransferService moneyTransferIntergrationService = _moneyTransferIntegrationServiceFactory.Create();
            bool cancelMoneyTrasnferResponse = moneyTransferIntergrationService.CancelMoneyTransfer(integrationRequest);

            if (cancelMoneyTrasnferResponse)
                moneyTransfer.Status = MoneyTransferStatus.Canceled;
            else
            {
                if (moneyTransfer.Attempts <= _settings.Attempts)
                    moneyTransferRepository.UpdateAttempts(moneyTransfer.MoneyTransferId);
                else
                    moneyTransfer.Status = MoneyTransferStatus.Error;
            }

            moneyTransferRepository.Update(moneyTransfer);
        }
    }
}
