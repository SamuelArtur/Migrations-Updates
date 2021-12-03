using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class User : BaseEntity
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string CellPhone { get; set; }
    }
}