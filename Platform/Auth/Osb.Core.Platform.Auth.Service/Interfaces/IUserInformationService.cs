using System.Threading.Tasks;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Result;

namespace Osb.Core.Platform.Auth.Service.Interfaces
{
    public interface IUserInformationService
    {
        void Save(UpdateUserInformationRequest userInformationRequest);

        UserInformationResult FindUserInformationByUserId(FindUserInformationRequest findUserInformationRequest);

        void Update(UpdateUserInformationRequest updateUserInformationRequest);
    }
}