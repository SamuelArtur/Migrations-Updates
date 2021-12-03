using System;
using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class InactivateCardRepository : IInactivateCardRepository
    {
        private readonly IDbContext<InactivateCard> _context;

        public InactivateCardRepository(IDbContext<InactivateCard> context)
        {
            this._context = context;
        }

        public void Save(InactivateCard inactivateCard)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramIdentifierCard"] = inactivateCard.IdentifierCard,
                ["paramAccountId"] = inactivateCard.AccountId,
                ["paramPin"] = inactivateCard.Pin,
                ["paramSalt"] = inactivateCard.Salt,
                ["paramStatus"] = inactivateCard.Status,
                ["paramReasonCode"] = Convert.ChangeType(inactivateCard.ReasonCode, inactivateCard.ReasonCode.GetTypeCode()),
                ["paramUserId"] = inactivateCard.UpdateUserId
            };

            _context.ExecuteWithNoResult("InsertInactivateCard", parameters);
        }

        public IEnumerable<InactivateCard> GetByStatus(InactivateCardStatus status, long? limit = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status,
                ["paramLimit"] = limit
            };

            IEnumerable<InactivateCard> InactivateCardList = _context.ExecuteWithMultipleResults("GetInactivateCardByStatus", parameters);

            return InactivateCardList;
        }
    }
}