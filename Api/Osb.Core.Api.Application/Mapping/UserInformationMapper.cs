using Osb.Core.Api.Application.Models.Request;
using AuthRequest = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class UserInformationMapper
    {
        public AuthRequest.UpdateUserInformationRequest Map(UpdateUserInformationRequest userInformationRequest)
        {
            return new AuthRequest.UpdateUserInformationRequest
            {
                UserId = userInformationRequest.UserId,
                AccountId = userInformationRequest.AccountId,
                Name = userInformationRequest.Name,
                Mail = userInformationRequest.Mail,
                CellPhone = userInformationRequest.CellPhone,
                ZipCode = userInformationRequest.ZipCode,
                Street = userInformationRequest.Street,
                Number = userInformationRequest.Number,
                District = userInformationRequest.District,
                Complement = userInformationRequest.Complement,
                City = userInformationRequest.City,
                State = userInformationRequest.State
            };
        }

        public AuthRequest.FindUserInformationRequest Map(FindUserInformationByUserIdRequest findUserInformationRequest)
        {
            return new AuthRequest.FindUserInformationRequest
            {
                UserId = findUserInformationRequest.UserId
            };
        }
    }
}