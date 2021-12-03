using Microsoft.AspNetCore.Mvc;
using Osb.Core.Webhook.Api.Filters;
using Osb.Core.Webhook.Api.Mapping;
using Osb.Core.Webhook.Api.Models.Request;
using Osb.Core.Webhook.Api.Models.Response;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountMapper _mapper;
        private readonly IAccountServiceFactory _serviceFactory;

        public AccountController(IAccountServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new AccountMapper();
        }

        /// <summary>
        /// Cria uma conta.
        /// </summary>
        /// <param name="accountRequest">Body da requisição</param>
        /// <returns>Criação da Conta</returns>
        /// <response code="200">Retona criação da conta especifica</response>
        /// <response code="400">Conta não criada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        public IActionResult Post([FromBody] AccountRequest accountRequest)
        {
            BusinessService.AccountRequest businessRequest = _mapper.Map(accountRequest);

            IAccountService accountService = _serviceFactory.Create();
            accountService.Save(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}