using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IActivateCardRepository
    {
        void Save(ActivateCard activateCard);
        IEnumerable<ActivateCard> GetListByStatus(ActivateCardStatus status);
        void Update(ActivateCard activateCard);
        void UpdateAttempts(long activateCardId);
        ActivateCard GetByIdentifier(string identifier);
    }
}