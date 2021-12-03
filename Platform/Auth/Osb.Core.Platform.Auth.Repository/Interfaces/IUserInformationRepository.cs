using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IUserInformationRepository
    {
        void Save(UserInformation userInformation);

        void Update(dynamic userInformationRequest);

        UserInformation GetByUserId(long userId);


    }
}