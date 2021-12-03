using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Repository
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private IDbContext<UserInformation> _context;


        public UserInformationRepository(IDbContext<UserInformation> context)
        {
            _context = context;
        }

        public void Save(UserInformation userInformation)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramName"] = userInformation.Name,
                ["paramMail"] = userInformation.Mail,
                ["paramCellPhone"] = userInformation.CellPhone,
                ["paramZipCode"] = userInformation.ZipCode,
                ["paramStreet"] = userInformation.Street,
                ["paramNumber"] = userInformation.Number,
                ["paramDistrict"] = userInformation.District,
                ["paramComplement"] = userInformation.Complement,
                ["paramCity"] = userInformation.City,
                ["paramState"] = userInformation.State,
                ["paramUserId"] = userInformation.UserId,
            };

            _context.ExecuteWithNoResult("insertuserinformation", parameters);
        }

        public void Update(dynamic userInformationRequest)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userInformationRequest.UserId,
                ["paramName"] = userInformationRequest.Name,
                ["paramMail"] = userInformationRequest.Mail,
                ["paramCellPhone"] = userInformationRequest.CellPhone,
                ["paramZipCode"] = userInformationRequest.ZipCode,
                ["paramStreet"] = userInformationRequest.Street,
                ["paramNumber"] = userInformationRequest.Number,
                ["paramDistrict"] = userInformationRequest.District,
                ["paramComplement"] = userInformationRequest.Complement,
                ["paramCity"] = userInformationRequest.City,
                ["paramState"] = userInformationRequest.State
            };

            _context.ExecuteWithNoResult("updateuserinformation", parameters);
        }

        public UserInformation GetByUserId(long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId
            };

            UserInformation userInformation = _context.ExecuteWithSingleResult("getuserinformationbyuserid", parameters);

            return userInformation;
        }
    }
}