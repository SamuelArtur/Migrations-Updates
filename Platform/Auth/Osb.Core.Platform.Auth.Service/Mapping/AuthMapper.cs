using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Service.Models.Result;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class AuthMapper
    {
        public AuthenticateResult Map(User user, UserCredential credential, string token)
        {
            return new AuthenticateResult
            {
                UserId = user.UserId,
                Name = user.Name,
                Mail = user.Mail,
                TaxId = user.Login,
                Token = token
            };
        }
    }
}