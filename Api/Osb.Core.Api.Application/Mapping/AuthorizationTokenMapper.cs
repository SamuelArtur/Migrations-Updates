using Osb.Core.Api.Application.Models.Request;
using AuthRequest = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class AuthorizationTokenMapper
    {
        public AuthRequest.AuthorizationTokenRequest Map(AuthorizationTokenRequest generateTokenRequest)
        {
            return new AuthRequest.AuthorizationTokenRequest
            {
                UserId = generateTokenRequest.UserId,
                AccountId = generateTokenRequest.AccountId
            };
        }
        public AuthRequest.ValidateAuthorizationTokenRequest Map(ValidateAuthorizationTokenRequest validateAuthorizationTokenRequest)
        {
            return new AuthRequest.ValidateAuthorizationTokenRequest
            {
                Code = validateAuthorizationTokenRequest.Code,
                UserId = validateAuthorizationTokenRequest.UserId,
                AccountId = validateAuthorizationTokenRequest.AccountId
            };
        }
    }
}