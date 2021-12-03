using System;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Util.Security;
using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Validators;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Service.Mapping;
using Osb.Core.Platform.Auth.Util.Resources;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Auth.Service
{
    public class AuthorizationTokenService : IAuthorizationTokenService
    {
        private readonly AuthorizationTokenValidator _validator;
        private readonly IAuthorizationTokenRepositoryFactory _tokenRepositoryFactory;
        private readonly IAuthorizationTokenRepositoryFactory _authorizationTokenRepositoryFactory;
        private readonly AuthorizationTokenMapper _mapper;
        private readonly Settings _settings;
        private readonly INotificationServiceFactory _notificationIntegrationServiceFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;

        public AuthorizationTokenService(
            IAuthorizationTokenRepositoryFactory tokenRepositoryFactory,
            IAuthorizationTokenRepositoryFactory authorizationTokenRepositoryFactory,
            Settings settings,
            INotificationServiceFactory notificationServiceFactory,
            IUserRepositoryFactory userRepositoryFactory)
        {
            _tokenRepositoryFactory = tokenRepositoryFactory;
            _validator = new AuthorizationTokenValidator();
            _authorizationTokenRepositoryFactory = authorizationTokenRepositoryFactory;
            _notificationIntegrationServiceFactory = notificationServiceFactory;
            _userRepositoryFactory = userRepositoryFactory;
            _mapper = new AuthorizationTokenMapper();
            _settings = settings;
        }

        public void GenerateAuthorizationToken(AuthorizationTokenRequest generateAuthorizationTokenRequest)
        {
            _validator.Validate(generateAuthorizationTokenRequest);

            IAuthorizationTokenRepository generateAuthorizationTokenRepository = _authorizationTokenRepositoryFactory.Create();
            generateAuthorizationTokenRepository.UnauthorizeTokensByUserIdAndAccountId(generateAuthorizationTokenRequest.UserId, generateAuthorizationTokenRequest.AccountId);

            Random valueUtility = new Random();
            long value = valueUtility.Next(111111, 999999);

            AuthorizationToken token = _mapper.Map(
                generateAuthorizationTokenRequest.UserId,
                generateAuthorizationTokenRequest.AccountId,
                value,
                _settings.ConnectionKey["AuthorizationTokenExpirationTime"]
                );

            generateAuthorizationTokenRepository.Save(token);

            IUserRepository _userRepository = _userRepositoryFactory.Create();
            User user = _userRepository.GetById(token.UserId);

            IntegrationService.INotificationService notificationIntergrationService = _notificationIntegrationServiceFactory.Create();

            IntegrationRequest.SendSmsRequest sendSmsRequest = _mapper.Map<IntegrationRequest.SendSmsRequest>(SendType.Sms, value, generateAuthorizationTokenRequest.AccountId, user);
            notificationIntergrationService.SendSms(sendSmsRequest);

            IntegrationRequest.SendMailRequest sendMailRequest = _mapper.Map<IntegrationRequest.SendMailRequest>(SendType.Mail, value, generateAuthorizationTokenRequest.AccountId, user);
            notificationIntergrationService.SendMail(sendMailRequest);
        }

        public void ValidateAuthorizationToken(ValidateAuthorizationTokenRequest validateAuthorizationTokenRequest)
        {
            _validator.Validate(validateAuthorizationTokenRequest);

            IAuthorizationTokenRepository authorizationTokenRepository = _authorizationTokenRepositoryFactory.Create();
            AuthorizationToken authorizationToken = authorizationTokenRepository.GetByUserIdAndAccountId(validateAuthorizationTokenRequest.UserId, validateAuthorizationTokenRequest.AccountId);

            if (authorizationToken == null)
                throw new OsbAuthException(AuthExcMsg.EXC0008);

            if (authorizationToken.ExpirationDate < DateTime.Now)
                throw new OsbAuthException(AuthExcMsg.EXC0009);

            authorizationTokenRepository.UpdateAttempts(authorizationToken.AuthorizationTokenId);
            authorizationToken.ValidateAttempts += 1;

            bool match = SHA512Provider.Compare(validateAuthorizationTokenRequest.Code, authorizationToken.Code, authorizationToken.Salt);

            if (!match)
            {
                if (authorizationToken.ValidateAttempts == _settings.AuthorizationTokenValidateAttempts)
                {
                    authorizationToken.Status = AuthorizationTokenStatus.Canceled;
                    authorizationTokenRepository.Update(authorizationToken, validateAuthorizationTokenRequest.UserId);
                    throw new OsbAuthException(AuthExcMsg.EXC0021);
                }

                throw new OsbAuthException(AuthExcMsg.EXC0010);
            }

            authorizationToken.Status = AuthorizationTokenStatus.Authorized;
            authorizationTokenRepository.Update(authorizationToken, validateAuthorizationTokenRequest.UserId);
        }
    }
}