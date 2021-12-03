using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Common.Entity;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Validators;

namespace Osb.Core.Platform.Business.Service
{
    public class BoletoPaymentService : IBoletoPaymentService
    {
        private readonly BoletoPaymentMapper _mapper;
        private readonly IBoletoPaymentServiceFactory _boletoPaymentIntegrationServiceFactory;
        private readonly IBoletoPaymentRepositoryFactory _boletoPaymentRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly Settings _settings;
        private IConnectionFactory _connectionFactory;
        private readonly BoletoPaymentValidator _validator;

        public BoletoPaymentService(
            IBoletoPaymentServiceFactory boletoPaymentIntegrationServiceFactory,
            IBoletoPaymentRepositoryFactory boletoPaymentRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            Settings settings,
            IConnectionFactory connectionFactory
        )
        {
            _boletoPaymentIntegrationServiceFactory = boletoPaymentIntegrationServiceFactory;
            _boletoPaymentRepositoryFactory = boletoPaymentRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _settings = settings;
            _mapper = new BoletoPaymentMapper();
            _connectionFactory = connectionFactory;
            _validator = new BoletoPaymentValidator();
        }

        public void Save(BoletoPaymentRequest boletoPaymentRequest)
        {

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                BoletoPayment boletoPayment = BoletoPayment.Create(boletoPaymentRequest.UserId,
                                                               boletoPaymentRequest.AccountId,
                                                               boletoPaymentRequest.Name,
                                                               boletoPaymentRequest.TaxId,
                                                               boletoPaymentRequest.ReceiverName,
                                                               boletoPaymentRequest.ReceiverTaxId,
                                                               boletoPaymentRequest.PayerName,
                                                               boletoPaymentRequest.PayerTaxId,
                                                               boletoPaymentRequest.Barcode,
                                                               boletoPaymentRequest.PaymentValue,
                                                               boletoPaymentRequest.PaymentDate,
                                                               boletoPaymentRequest.DueDate,
                                                               boletoPaymentRequest.DiscountValue,
                                                               boletoPaymentRequest.Description,
                                                               boletoPaymentRequest.Identifier);

                IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
                boletoPaymentRepository.Save(boletoPayment, transactionScope);

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

        public void GenerateBoletoPayment(BoletoPayment boletoPayment)
        {
            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(boletoPayment.AccountId);

            IntegrationRequest.BoletoPaymentRequest integrationRequest = _mapper.Map(boletoPayment, account);

            IntegrationService.IBoletoPaymentService boletoPaymentService = _boletoPaymentIntegrationServiceFactory.Create();
            IntegrationResponse.BoletoPaymentResponse boletoPaymentResponse = boletoPaymentService.GenerateBoletoPayment(integrationRequest);

            IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
            if (boletoPaymentResponse.Status && boletoPaymentResponse.ExternalIdentifier > 0)
            {
                boletoPayment.Status = BoletoPaymentStatus.Generated;
                boletoPayment.ExternalIdentifier = boletoPaymentResponse.ExternalIdentifier.ToString();
                boletoPaymentRepository.Update(boletoPayment);
            }
            else
            {
                if (boletoPayment.Attempts <= _settings.Attempts)
                    boletoPaymentRepository.UpdateAttempts(boletoPayment.BoletoPaymentId);
                else
                {
                    boletoPayment.Status = BoletoPaymentStatus.Error;
                    boletoPaymentRepository.Update(boletoPayment);
                }
            }
        }

        public IEnumerable<BoletoPayment> FindBoletoPaymentListByStatus(BoletoPaymentStatus status)
        {
            IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
            IEnumerable<BoletoPayment> boletoPaymentList = boletoPaymentRepository.GetListByStatus(status);

            return boletoPaymentList;
        }

        public FindInfosPaymentCIPByBarcodeResult FindInfosPaymentCIPByBarcode(FindInfosPaymentCIPByBarcodeRequest findInfosPaymentCIPByBarcodeRequest)
        {
            IntegrationRequest.FindInfosPaymentCIPByBarcodeRequest integrationRequest = _mapper.Map(findInfosPaymentCIPByBarcodeRequest);

            IntegrationService.IBoletoPaymentService paymentIntegrationService = _boletoPaymentIntegrationServiceFactory.Create();
            IntegrationResponse.FindInfosPaymentCIPByBarcodeResponse findInfosPaymentCIPByBarcodeResponse = paymentIntegrationService.FindInfosPaymentCIPByBarcode(integrationRequest);

            FindInfosPaymentCIPByBarcodeResult result = _mapper.Map(findInfosPaymentCIPByBarcodeResponse);
            return result;
        }

        public FindInfosPaymentByBarcodeResult FindInfosPaymentByBarcode(FindInfosPaymentByBarcodeRequest findInfosBarcodeRequest)
        {
            IntegrationRequest.FindInfosPaymentByBarcodeRequest integrationRequest = _mapper.Map(findInfosBarcodeRequest);

            IntegrationService.IBoletoPaymentService paymentIntegrationService = _boletoPaymentIntegrationServiceFactory.Create();
            IntegrationResponse.FindInfosPaymentByBarcodeReponse findInfosPaymentByBarcodeResponse = paymentIntegrationService.FindInfosPaymentByBarcode(integrationRequest);

            FindInfosPaymentByBarcodeResult result = _mapper.Map(findInfosPaymentByBarcodeResponse);
            return result;
        }

        public void VerifiyBoletoCanBePaid(VerifiyBoletoCanBePaidRequest verifiyBoletoCanBePaidRequest)
        {
            IntegrationRequest.VerifiyBoletoCanBePaidRequest integrationRequest = _mapper.Map(verifiyBoletoCanBePaidRequest);

            IntegrationService.IBoletoPaymentService paymentIntegrationService = _boletoPaymentIntegrationServiceFactory.Create();
            IntegrationResponse.VerifiyBoletoCanBePaidResponse verifiyBoletoCanBePaidResponse = paymentIntegrationService.VerifiyBoletoCanBePaid(integrationRequest);

            if (!verifiyBoletoCanBePaidResponse.CanBePaid)
                throw new OsbBusinessException("Boleto não pode ser pago");
        }

        public void UpdateBoletoPaymentStatus(UpdateBoletoPaymentStatusRequest updateBoletoPaymentStatusRequest)
        {
            IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
            BoletoPayment boletoPayment = boletoPaymentRepository.GetByIdentifier(updateBoletoPaymentStatusRequest.Identifier);

            boletoPayment.Status = updateBoletoPaymentStatusRequest.Status;
            boletoPaymentRepository.Update(boletoPayment);
        }

        public void UpdateBoletoPaymentAttempts(long boletoPaymentId)
        {
            IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
            boletoPaymentRepository.UpdateAttempts(boletoPaymentId);
        }

        public FindExpectedBoletoPaymentDateResult FindExpectedBoletoPaymentDate(FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            _validator.Validate(findExpectedBoletoPaymentDateRequest);

            IntegrationRequest.FindExpectedBoletoPaymentDateRequest integrationRequest = _mapper.Map(findExpectedBoletoPaymentDateRequest);

            IntegrationService.IBoletoPaymentService paymentIntegrationService = _boletoPaymentIntegrationServiceFactory.Create();
            IntegrationResponse.FindExpectedBoletoPaymentDateResponse findExpectedBoletoPaymentDateResponse = paymentIntegrationService.FindExpectedBoletoPaymentDate(integrationRequest);

            FindExpectedBoletoPaymentDateResult result = _mapper.Map(findExpectedBoletoPaymentDateResponse);
            return result;
        }
    }
}