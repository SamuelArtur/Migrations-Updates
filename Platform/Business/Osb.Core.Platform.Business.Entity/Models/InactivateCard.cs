using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class InactivateCard : BaseEntity
    {
        public long InactivateCardId { get; set; }
        public long AccountId { get; set; }
        public string IdentifierCard { get; set; }
        public string Pin { get; set; }
        public ReasonCodeCard ReasonCode { get; set; }
        public InactivateCardStatus Status { get; set; }
        public string Salt { get; set; }

        public static InactivateCard Create(string identifierCard, long accountId, string pin, string salt, ReasonCodeCard reasonCode, long userId)
        {
            return new InactivateCard
            {
                IdentifierCard = identifierCard,
                AccountId = accountId,
                Pin = pin,
                Salt = salt,
                ReasonCode = reasonCode,
                Status = InactivateCardStatus.Created,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}