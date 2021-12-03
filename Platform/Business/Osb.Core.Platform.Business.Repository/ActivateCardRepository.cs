using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class ActivateCardRepository : IActivateCardRepository
    {
        private readonly IDbContext<ActivateCard> _context;

        public ActivateCardRepository(IDbContext<ActivateCard> context)
        {
            this._context = context;
        }

        public void Save(ActivateCard activateCard)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = activateCard.Status,
                ["paramIdentifierCard"] = activateCard.IdentifierCard,
                ["paramAccountId"] = activateCard.AccountId,
                ["paramUserId"] = activateCard.CreationUserId
            };

            _context.ExecuteWithNoResult("InsertActivateCard", parameters);
        }

        public IEnumerable<ActivateCard> GetListByStatus(ActivateCardStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            IEnumerable<ActivateCard> activateCardList = _context.ExecuteWithMultipleResults("GetActivateCardListByStatus", parameters);

            return activateCardList;
        }

        public void Update(ActivateCard activateCard)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramActivateCardId"] = activateCard.ActivateCardId,
                ["paramStatus"] = activateCard.Status
            };

            _context.ExecuteWithNoResult("UpdateActivateCard", parameters);
        }

        public void UpdateAttempts(long activateCardId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramActivateCardId"] = activateCardId
            };

            _context.ExecuteWithNoResult("UpdateActivateCardAttempts", parameters);
        }

        public ActivateCard GetByIdentifier(string identifier)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramIdentifierCard"] = identifier
            };

            ActivateCard card = _context.ExecuteWithSingleResult("GetActivateCardByIdentifier", parameters);

            return card;
        }
    }
}