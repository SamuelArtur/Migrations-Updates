using System.Threading.Tasks;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Result;

namespace Osb.Core.Platform.Auth.Service.Interfaces
{
    public interface IAuthService
    {
        AuthenticateResult Authenticate(AuthenticateRequest userRequest);
    }
}