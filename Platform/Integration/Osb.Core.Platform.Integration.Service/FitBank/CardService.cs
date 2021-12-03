using Osb.Core.Platform.Integration.Entity.Fitbank.Models.Response;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Service
{
    public class CardService : ICardService
    {
        public readonly CardMapper _mapper = new CardMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly Settings _settings;

        public CardService(
           ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
           Settings settings
       )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _settings = settings;
        }

        public ActivateCardResponse ActivateCard(ActivateCardRequest activateCardRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                activateCardRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(activateCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ActivateCardResponse response = _mapper.Map<ActivateCardResponse>(externalResponse);

            return response;
        }

        public InactivateAndReissueCardResponse InactivateAndReissueCard(InactivateAndReissueCardRequest inactivateAndReissueCardRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                inactivateAndReissueCardRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(inactivateAndReissueCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            InactivateAndReissueCardResponse response = _mapper.Map<InactivateAndReissueCardResponse>(externalResponse);

            return response;
        }
    }
}