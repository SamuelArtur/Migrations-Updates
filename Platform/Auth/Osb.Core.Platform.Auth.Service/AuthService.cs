using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Result;
using Osb.Core.Platform.Auth.Service.Validators;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Mapping;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Util.Resources;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Util.Security;

namespace Osb.Core.Platform.Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly AuthValidator _validator;
        private readonly AuthMapper _mapper;
        private readonly IAuthRepositoryFactory _authRepositoryFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;
        private readonly IUserCredentialLogRepositoryFactory _userCredentialLogRepositoryFactory;
        private readonly Settings _settings;

        public AuthService(
            IAuthRepositoryFactory authRepositoryFactory,
            IUserRepositoryFactory userRepositoryFactory,
            IUserCredentialLogRepositoryFactory userCredentialLogRepositoryFactory,
            Settings settings)
        {
            _authRepositoryFactory = authRepositoryFactory;
            _userRepositoryFactory = userRepositoryFactory;
            _userCredentialLogRepositoryFactory = userCredentialLogRepositoryFactory;
            _settings = settings;
            _validator = new AuthValidator();
            _mapper = new AuthMapper();
        }

        public AuthenticateResult Authenticate(AuthenticateRequest authenticateRequest)
        {
            _validator.Validate(authenticateRequest);

            IUserRepository _userRepository = _userRepositoryFactory.Create();
            User user = _userRepository.GetUserByLogin(authenticateRequest.Login);
            if (user == null)
                throw new OsbAuthException(AuthExcMsg.EXC0002);

            IAuthRepository _authRepository = _authRepositoryFactory.Create();
            UserCredential userCredential = _authRepository.GetUserCredentialByUserId(user.UserId);
            if (userCredential == null)
                throw new OsbAuthException(AuthExcMsg.EXC0001);

            CompareCredential(authenticateRequest, userCredential);

            string jwtToken = GenerateJwtToken(authenticateRequest, user.UserId.ToString());

            AuthenticateResult authenticateResult = _mapper.Map(user, userCredential, jwtToken);
            IUserCredentialLogRepository userCredentialLogRepository = _userCredentialLogRepositoryFactory.Create();
            userCredentialLogRepository.Save(user.Login, user.UserId, DateTime.Now, DateTime.Now);

            return authenticateResult;
        }

        public string GenerateJwtToken(AuthenticateRequest authenticateRequest, string userId)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(_settings.JwtSecret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, authenticateRequest.Login),
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, "default")
                    //TODO: Adicionar o role quando estivermos trabalhando com profile
                }),
                Expires = DateTime.UtcNow.AddHours(_settings.JwtExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private void CompareCredential(AuthenticateRequest request, UserCredential credential)
        {
            bool match = SHA512Provider.Compare(request.Password, credential.Password, credential.Salt);
            if (!match)
                throw new OsbAuthException(AuthExcMsg.EXC0007);
        }
    }
}