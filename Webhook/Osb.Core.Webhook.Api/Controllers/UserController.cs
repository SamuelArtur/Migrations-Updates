using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Osb.Core.Webhook.Api.Filters;
using Osb.Core.Webhook.Api.Mapping;
using Osb.Core.Webhook.Api.Models.Request;
using Osb.Core.Webhook.Api.Models.Response;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Interfaces;
using AuthService = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserMapper _mapper;
        private readonly IUserServiceFactory _serviceFactory;

        public UserController(IUserServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new UserMapper();
        }

        /// <summary>
        /// Cria e edita um User.
        /// </summary>
        /// <param name="userRequest">Body da requisição</param>
        /// <returns>Criação e Atualização de um User</returns>
        /// <response code="200">Retona criação e atualizaçao de um User especifico</response>
        /// <response code="400">User não criado, atualiza ou excluído</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        public IActionResult Post([FromBody] UserRequest userRequest)
        {
            AuthService.UserRequest authRequest = _mapper.Map(userRequest);

            IUserService userService = _serviceFactory.Create();
            userService.Save(authRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}