using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Util.Resources;
using Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Platform.Auth.Service.Validators
{
    public class UserValidator
    {
        public void Validate(UpdateUserInformationRequest userInformationRequest)
        {
            if (string.IsNullOrEmpty(userInformationRequest.Name))
                throw new OsbAuthException(AuthExcMsg.EXC0013);

            if (string.IsNullOrEmpty(userInformationRequest.Mail))
                throw new OsbAuthException(AuthExcMsg.EXC0014);

            if (string.IsNullOrEmpty(userInformationRequest.CellPhone))
                throw new OsbAuthException(AuthExcMsg.EXC0015);

            if (string.IsNullOrEmpty(userInformationRequest.ZipCode))
                throw new OsbAuthException(AuthExcMsg.EXC0016);

            if (string.IsNullOrEmpty(userInformationRequest.Street))
                throw new OsbAuthException(AuthExcMsg.EXC0017);

            if (string.IsNullOrEmpty(userInformationRequest.District))
                throw new OsbAuthException(AuthExcMsg.EXC0018);

            if (string.IsNullOrEmpty(userInformationRequest.City))
                throw new OsbAuthException(AuthExcMsg.EXC0019);

            if (string.IsNullOrEmpty(userInformationRequest.State))
                throw new OsbAuthException(AuthExcMsg.EXC0020);
        }

        public void Validate(FindUserInformationRequest findUserInformationRequest)
        {
            if (findUserInformationRequest.UserId == 0)
                throw new OsbAuthException(AuthExcMsg.EXC0012);
        }

        public void Validate(UserRequest userRequest)
        {
            // if (string.IsNullOrEmpty(userRequest.TaxId))
            //     throw new OsbAuthException(AuthExcMsg.EXC0005);

            // if (string.IsNullOrEmpty(userRequest.AccountName))
            //     throw new OsbAuthException(AuthExcMsg.EXC0014); 

            // if (string.IsNullOrEmpty(userRequest.AccountTaxId))
            //     throw new OsbAuthException(AuthExcMsg.EXC0015); 

            // if (string.IsNullOrEmpty(userRequest.Name))
            //     throw new OsbAuthException(AuthExcMsg.EXC0013); 

            // if (string.IsNullOrEmpty(userRequest.Email))
            //     throw new OsbAuthException(AuthExcMsg.EXC0016); 

            // if (string.IsNullOrEmpty(userRequest.CellPhone))
            //     throw new OsbAuthException(AuthExcMsg.EXC0017); 

            // if (string.IsNullOrEmpty(userRequest.UserTaxId))
            //     throw new OsbAuthException(AuthExcMsg.EXC0018);  

            // if (userRequest.CompanyId == 0)
            //     throw new OsbAuthException(AuthExcMsg.EXC0019);  
        }
    }
}