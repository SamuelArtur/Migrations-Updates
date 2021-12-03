using System;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class UserCredential : BaseEntity
    {        
        public long UserCredentialId { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}