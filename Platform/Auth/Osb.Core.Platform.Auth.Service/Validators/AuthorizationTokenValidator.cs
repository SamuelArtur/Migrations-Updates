using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Util.Resources;

namespace Osb.Core.Platform.Auth.Service.Validators
{
    public class AuthorizationTokenValidator
    {
        public void Validate(ValidateAuthorizationTokenRequest validateTokenRequest)
        {
            if(string.IsNullOrEmpty(validateTokenRequest.Code))
                throw new OsbAuthException(AuthExcMsg.EXC0001);
        }
         public void Validate(AuthorizationTokenRequest generateAuthorizationTokenRequest)
        {
            if(generateAuthorizationTokenRequest == null)
                throw new OsbAuthException(AuthExcMsg.EXC0004);
        }
    }
}