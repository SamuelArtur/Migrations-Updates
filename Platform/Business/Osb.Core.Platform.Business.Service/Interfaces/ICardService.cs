using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface ICardService
    {
        void Activate(ActivateCardRequest activateCardRequest);
        void InactivateAndReissue(InactivateAndReissueCardRequest inactivateAndReissueCardRequest);
        void ActivateList(ActivateCard card);
        IEnumerable<ActivateCard> FindCardListByStatus(ActivateCardStatus status);
        void Update(UpdateCardStatusRequest updateCardStatusRequest);
        void UpdateAttempts(long cardId);
    }
}