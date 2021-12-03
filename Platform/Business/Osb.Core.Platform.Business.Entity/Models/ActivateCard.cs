using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class ActivateCard : BaseEntity
    {

        public long AccountId { get; set; }
        public long ActivateCardId { get; set; }
        public string IdentifierCard { get; set; }
        public ActivateCardStatus Status { get; set; }
        public int Attempts { get; set; }

        public static ActivateCard Create(long accountId, long userId, string identifierCard)
        {
            return new ActivateCard
            {
                AccountId = accountId,
                CreationUserId = userId,
                UpdateUserId = userId,
                IdentifierCard = identifierCard,
                Status = ActivateCardStatus.Created
            };
        }
    }
}