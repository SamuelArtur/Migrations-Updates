using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Api.Common.Resources;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Models.Result;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// Autenticação de usuários
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthMapper _mapper;
        private readonly IAuthServiceFactory _serviceFactory;

        public AuthController(IAuthServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new AuthMapper();
        }

        /// <summary>
        /// Realiza autenticação do usuário e gera token de acesso
        /// </summary>
        /// <param name="loginRequest">Credenciais</param>
        /// <returns>Autenticação de usuário</returns>
        /// <response code="200">Autenticação realizada com sucesso</response>
        /// <response code="400">Usuário não encontrado</response>

        [ValidateCredentialRequestFilter]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            AuthenticateRequest authenticateRequest = _mapper.Map(loginRequest);

            IAuthService authService = _serviceFactory.Create();
            AuthenticateResult authenticateResult = authService.Authenticate(authenticateRequest);

            Response response = ResponseMapper.Map(true, authenticateResult, ApiInfoMsg.ApiInfo0004);
            return Ok(response);
        }
    }
}