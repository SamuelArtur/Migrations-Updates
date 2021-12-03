using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Result;
using Osb.Core.Platform.Auth.Service.Validators;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Mapping;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Util.Resources;

namespace Osb.Core.Platform.Auth.Service
{
    public class UserInformationService : IUserInformationService
    {
        private readonly UserValidator _validator;
        private readonly UserMapper _mapper;
        private readonly IUserInformationRepositoryFactory _userInformationRepositoryFactory;

        public UserInformationService(

            IUserInformationRepositoryFactory userInformationRepositoryFactory)
        {
            _userInformationRepositoryFactory = userInformationRepositoryFactory;
            _validator = new UserValidator();
            _mapper = new UserMapper();
        }

        public void Save(UpdateUserInformationRequest userInformationRequest)
        {
            _validator.Validate(userInformationRequest);

            UserInformation userInformation = UserInformation.Create(
                userInformationRequest.UserId,
                userInformationRequest.Name,
                userInformationRequest.Mail,
                userInformationRequest.CellPhone,
                userInformationRequest.ZipCode,
                userInformationRequest.Street,
                userInformationRequest.Number,
                userInformationRequest.District,
                userInformationRequest.Complement,
                userInformationRequest.City,
                userInformationRequest.State
            );

            IUserInformationRepository userInformationRepository = _userInformationRepositoryFactory.Create();
            userInformationRepository.Save(userInformation);
        }

        public UserInformationResult FindUserInformationByUserId(FindUserInformationRequest findUserInformationRequest)
        {
            _validator.Validate(findUserInformationRequest);

            IUserInformationRepository userInformationRepository = _userInformationRepositoryFactory.Create();
            UserInformation userInformation = userInformationRepository.GetByUserId(findUserInformationRequest.UserId);

            UserInformationResult result = _mapper.Map(userInformation);
            return result;
        }

        public void Update(UpdateUserInformationRequest userInformationRequest)
        {
            _validator.Validate(userInformationRequest);

            IUserInformationRepository userInformationRepository = _userInformationRepositoryFactory.Create();
            UserInformation userInformation = userInformationRepository.GetByUserId(userInformationRequest.UserId);

            if (userInformation == null)
                throw new OsbAuthException(AuthExcMsg.EXC0002);

            userInformationRepository.Update(userInformationRequest);
        }
    }
}