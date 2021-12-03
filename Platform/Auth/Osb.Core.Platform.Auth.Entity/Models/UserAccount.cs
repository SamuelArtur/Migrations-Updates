using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity
{
    public class UserAccount : BaseEntity
    {
        public long UserAccountId { get; set; }
        public long AccountId { get; set; }
        public long UserId { get; set; }
    }
}