using Microsoft.AspNetCore.Mvc;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Common.Resources;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Interfaces;
using BusinessService = Osb.Core.Platform.Auth.Service.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationTokenController : ControllerBase
    {
        private readonly AuthorizationTokenMapper _mapper;
        private readonly IAuthorizationTokenServiceFactory _serviceFactory;

        public AuthorizationTokenController(IAuthorizationTokenServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new AuthorizationTokenMapper();
        }

        /// <summary>
        /// Gera um token 
        /// </summary>
        /// <param name="generateAuthorizationTokenRequest">Id da Account</param>
        /// <returns>Token</returns>
        /// <response code="200">Gera um token</response>
        /// <response code="400">Não foi possível gerar o token</response>

        [HttpPost("")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        public IActionResult Post([FromBody] AuthorizationTokenRequest generateAuthorizationTokenRequest)
        {
            BusinessService.AuthorizationTokenRequest generateAuthorizationTokenServiceRequest = _mapper.Map(generateAuthorizationTokenRequest);

            IAuthorizationTokenService generateTokenService = _serviceFactory.Create();
            generateTokenService.GenerateAuthorizationToken(generateAuthorizationTokenServiceRequest);

            Response response = ResponseMapper.Map(true, null, ApiInfoMsg.ApiInfo0002);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        public IActionResult ValidateAuthorizationToken([FromBody] ValidateAuthorizationTokenRequest validateAuthorizationTokenRequest)
        {
            BusinessService.ValidateAuthorizationTokenRequest validateAuthorizationTokenServiceRequest = _mapper.Map(validateAuthorizationTokenRequest);

            IAuthorizationTokenService validateAuthorizationTokenService = _serviceFactory.Create();
            validateAuthorizationTokenService.ValidateAuthorizationToken(validateAuthorizationTokenServiceRequest);

            Response response = ResponseMapper.Map(true, null, ApiInfoMsg.ApiInfo0005);
            return Ok(response);
        }
    }
}