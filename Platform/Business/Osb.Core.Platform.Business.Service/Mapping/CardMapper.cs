using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class CardMapper
    {
        public IntegrationRequest.ActivateCardRequest Map(ActivateCard activateCard)
        {
            return new IntegrationRequest.ActivateCardRequest
            {
                AccountId = activateCard.AccountId,
                IdentifierCard = activateCard.IdentifierCard
            };
        }

        public IntegrationRequest.InactivateAndReissueCardRequest Map(InactivateCard inactivateCard)
        {
            return new IntegrationRequest.InactivateAndReissueCardRequest
            {
                AccountId = inactivateCard.AccountId,
                Pin = inactivateCard.Pin,
                IdentifierCard = inactivateCard.IdentifierCard,
                ReasonCode = inactivateCard.ReasonCode.ToString()
            };
        }
    }
}