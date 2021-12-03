using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Platform.Common.Util.Security;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class CardMapper
    {
        public BusinessRequest.ActivateCardRequest Map(ActivateCardRequest activateCardRequest)
        {
            return new BusinessRequest.ActivateCardRequest
            {
                AccountId = activateCardRequest.AccountId,
                UserId = activateCardRequest.UserId,
                IdentifierCard = activateCardRequest.IdentifierCard
            };
        }

        public BusinessRequest.InactivateAndReissueCardRequest Map(InactivateAndReissueCardRequest inactivateAndReissueCardRequest)
        {
            return new BusinessRequest.InactivateAndReissueCardRequest
            {
                AccountId = inactivateAndReissueCardRequest.AccountId,
                IdentifierCard = inactivateAndReissueCardRequest.IdentifierCard,
                Pin = inactivateAndReissueCardRequest.Pin,
                ReasonCode = inactivateAndReissueCardRequest.ReasonCode,
                Salt = SHA512Provider.GenerateSalt(),
                UserId = inactivateAndReissueCardRequest.UserId
            };
        }
    }
}