using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Service.Models.Result;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class UserMapper : Mapper
    {
        public UserInformationResult Map(UserInformation userInformation)
        {
            return new UserInformationResult
            {
                Name = userInformation.Name,
                Mail = userInformation.Mail,
                CellPhone = userInformation.CellPhone,
                ZipCode = userInformation.ZipCode,
                Street = userInformation.Street,
                Number = userInformation.Number,
                District = userInformation.District,
                Complement = userInformation.Complement,
                City = userInformation.City,
                State = userInformation.State
            };
        }
    }
}