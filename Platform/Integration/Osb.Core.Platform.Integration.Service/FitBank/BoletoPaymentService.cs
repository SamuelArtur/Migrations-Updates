using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Common;
using Osb.Core.Platform.Integration.Service.FitBankServices.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class BoletoPaymentService : IBoletoPaymentService
    {
        public readonly BoletoPaymentMapper _mapper = new BoletoPaymentMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly Settings _settings;

        public BoletoPaymentService(ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory, Settings settings)
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _settings = settings;
        }

        public BoletoPaymentResponse GenerateBoletoPayment(BoletoPaymentRequest boletoPaymentRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                boletoPaymentRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(boletoPaymentRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExternalBoletoPaymentInfosResponse externalBoletoPaymentInfosResponse = _mapper.Map<ExternalBoletoPaymentInfosResponse>(externalResponse);

            if (!externalBoletoPaymentInfosResponse.Status)
                throw new OsbIntegrationException(externalBoletoPaymentInfosResponse.Message);

            BoletoPaymentResponse response = _mapper.Map<BoletoPaymentResponse>(externalResponse);

            return response;
        }
        public FindInfosPaymentCIPByBarcodeResponse FindInfosPaymentCIPByBarcode(FindInfosPaymentCIPByBarcodeRequest findInfosPaymentCIPByBarcodeRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findInfosPaymentCIPByBarcodeRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findInfosPaymentCIPByBarcodeRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExternalBoletoPaymentInfosResponse externalBoletoPaymentInfosResponse = _mapper.Map<ExternalBoletoPaymentInfosResponse>(externalResponse);

            if (!externalBoletoPaymentInfosResponse.Status)
                throw new OsbIntegrationException(externalBoletoPaymentInfosResponse.Message);

            FindInfosPaymentCIPByBarcodeResponse response = _mapper.Map<FindInfosPaymentCIPByBarcodeResponse>(externalBoletoPaymentInfosResponse.Data);

            return response;
        }

        public FindInfosPaymentByBarcodeReponse FindInfosPaymentByBarcode(FindInfosPaymentByBarcodeRequest findInfosPaymentByBarcodeRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findInfosPaymentByBarcodeRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findInfosPaymentByBarcodeRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExternalBoletoPaymentInfosResponse externalBoletoPaymentInfosResponse = _mapper.Map<ExternalBoletoPaymentInfosResponse>(externalResponse);

            if (!externalBoletoPaymentInfosResponse.Status)
                throw new OsbIntegrationException(externalBoletoPaymentInfosResponse.Message);

            FindInfosPaymentByBarcodeReponse response = _mapper.Map<FindInfosPaymentByBarcodeReponse>(externalBoletoPaymentInfosResponse.Data);

            return response;
        }

        public VerifiyBoletoCanBePaidResponse VerifiyBoletoCanBePaid(VerifiyBoletoCanBePaidRequest verifiyBoletoCanBePaidRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                verifiyBoletoCanBePaidRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(verifiyBoletoCanBePaidRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            VerifiyBoletoCanBePaidResponse response = _mapper.Map<VerifiyBoletoCanBePaidResponse>(externalResponse);

            return response;
        }

        public FindExpectedBoletoPaymentDateResponse FindExpectedBoletoPaymentDate(FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findExpectedBoletoPaymentDateRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findExpectedBoletoPaymentDateRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            var findExpectedBoletoPaymentDateResponse = _mapper.Map<ExternalFindExpectedBoletoPaymentDateResponse>(externalResponse);

            FindExpectedBoletoPaymentDateResponse response = _mapper.Map(findExpectedBoletoPaymentDateResponse);

            return response;
        }
    }
}