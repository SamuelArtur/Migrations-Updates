using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Common;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class InternalTransferService : IInternalTransferService
    {
        private readonly InternalTransferMapper _mapper = new InternalTransferMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly Settings _settings;

        public InternalTransferService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _settings = settings;
        }

        public InternalTransferResponse InternalTransfer(InternalTransferRequest internalTransferRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                internalTransferRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(internalTransferRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            InternalTransferResponse response = _mapper.Map<InternalTransferResponse>(externalResponse);
            return response;
        }

        public FindPendingInternalTransferResponse FindPendingInternalTransfer(FindPendingInternalTransferRequest findPendingInternalTransferRequest)
        {

            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId
            (
                findPendingInternalTransferRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findPendingInternalTransferRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExternalFindPendingInternalTransferResponse externalFindPendingInternalTransferResponse = _mapper.Map<ExternalFindPendingInternalTransferResponse>(externalResponse);

            if (!externalFindPendingInternalTransferResponse.Status)
                throw new OsbIntegrationException(externalFindPendingInternalTransferResponse.Message);

            FindPendingInternalTransferResponse response = _mapper.Map(externalFindPendingInternalTransferResponse);

            return response;
        }

        public bool CancelInternalTransfer(CancelInternalTransferRequest cancelInternalTransferRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                cancelInternalTransferRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(cancelInternalTransferRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            CancelInternalTransferResponse response = _mapper.Map<CancelInternalTransferResponse>(externalResponse);

            return response.Status;
        }
    }
}