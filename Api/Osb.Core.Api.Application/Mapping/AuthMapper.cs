using System.Text.RegularExpressions;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class AuthMapper
    {
        public AuthenticateRequest Map(LoginRequest authRequest)
        {
            string unmaskedLogin = Regex.Replace(authRequest.Login, @"[^\d]+", "");
            return new AuthenticateRequest
            {
                Login = unmaskedLogin,
                Password = authRequest.Password
            };
        }
    }
}