using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Models.Result;
using AuthService = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserInformationController : ControllerBase
    {
        private readonly UserInformationMapper _mapper;
        private readonly IUserInformationServiceFactory _serviceFactory;

        public UserInformationController(IUserInformationServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new UserInformationMapper();
        }

        /// <summary>
        /// Salva as informações do usuário.
        /// </summary>
        /// <param name="userInformationRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisção bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisção bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] UpdateUserInformationRequest userInformationRequest)
        {
            AuthService.UpdateUserInformationRequest authRequest = _mapper.Map(userInformationRequest);

            IUserInformationService userInformationService = _serviceFactory.Create();
            userInformationService.Save(authRequest);

            Response response = ResponseMapper.Map(true);

            return Ok(response);
        }

        /// <summary>
        /// Retorna as informações do usuário.
        /// </summary>
        /// <param name="findUserInformationByUserIdRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisção bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisção bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindUserInformationByUserId([FromBody] FindUserInformationByUserIdRequest findUserInformationByUserIdRequest)
        {
            AuthService.FindUserInformationRequest authRequest = _mapper.Map(findUserInformationByUserIdRequest);

            IUserInformationService userInformationService = _serviceFactory.Create();
            UserInformationResult result = userInformationService.FindUserInformationByUserId(authRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Atualiza as informações do usuário.
        /// </summary>
        /// <param name="updateUserInformationRequest">Body da requisição</param>
        /// <returns>Confirmação de uma requisção bem-sucedida</returns>
        /// <response code="200">Confirmação de uma requisção bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPut()]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Put([FromBody] UpdateUserInformationRequest updateUserInformationRequest)
        {
            AuthService.UpdateUserInformationRequest authRequest = _mapper.Map(updateUserInformationRequest);

            IUserInformationService userInformationService = _serviceFactory.Create();
            userInformationService.Update(authRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}