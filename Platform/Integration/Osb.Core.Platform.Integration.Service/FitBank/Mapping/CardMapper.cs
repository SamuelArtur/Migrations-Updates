using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class CardMapper : Mapper
    {
        public ExternalRequest Map(
           ActivateCardRequest activateCardRequest,
           CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                activateCardRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = activateCardRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    IdentifierCard = activateCardRequest.IdentifierCard
                }
            };
        }

        public ExternalRequest Map(
            InactivateAndReissueCardRequest cardRequest,
            CompanyAuthentication companyAuthentication
        )
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                cardRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = cardRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    IdentifierCard = cardRequest.IdentifierCard,
                    Pin = cardRequest.Pin,
                    ReasonCode = cardRequest.ReasonCode
                }
            };
        }
    }
}