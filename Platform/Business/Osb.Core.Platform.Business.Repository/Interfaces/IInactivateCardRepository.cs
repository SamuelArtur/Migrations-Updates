using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IInactivateCardRepository
    {
        void Save(InactivateCard inactivateCard);
        IEnumerable<InactivateCard> GetByStatus(InactivateCardStatus status, long? limit = null);
    }
}