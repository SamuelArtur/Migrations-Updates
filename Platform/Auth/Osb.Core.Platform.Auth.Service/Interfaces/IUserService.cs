using Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Platform.Auth.Service.Interfaces
{
    public interface IUserService
    {
         void Save(UserRequest userRequest);
    }
}