using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Util.Resources;

namespace Osb.Core.Platform.Auth.Service.Validators
{
    public class AuthValidator
    {
        public void Validate(AuthenticateRequest userRequest)
        {
            if (userRequest.Login == "")
                throw new OsbAuthException(AuthExcMsg.EXC0005);
                
            if (userRequest.Password == "")
                throw new OsbAuthException(AuthExcMsg.EXC0006);    
        }
    }
}