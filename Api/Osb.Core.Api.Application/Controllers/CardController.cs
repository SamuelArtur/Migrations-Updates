using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardMapper _mapper;
        private readonly ICardServiceFactory _serviceFactory;

        public CardController(ICardServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new CardMapper();
        }

        /// <summary>
        /// Realiza a ativação de um cartão.
        /// </summary>
        /// <param name="activateCardRequest">Body da requisição</param>
        /// <returns>Confirmação de uma transferência interna bem-sucedida</returns>
        /// <response code="200">Confirmação de ativação bem-sucedida</response>
        /// <response code="400">Erro de validação encontrada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Activate([FromBody] ActivateCardRequest activateCardRequest)
        {
            BusinessService.ActivateCardRequest businessRequest = _mapper.Map(activateCardRequest);

            ICardService cardService = _serviceFactory.Create();
            cardService.Activate(businessRequest);

            Response response = ResponseMapper.Map(true);

            return Ok(response);
        }

        /// <summary>
        /// Inativa o cartão do usuário e Solicita segunda via
        /// </summary>
        /// <param name="inactivateAndReissueCardRequest">Body da requisição</param>
        /// <returns>Identifier do Cartão</returns>
        /// <response code="200">Cartão inativado</response>
        /// <response code="400">Não foi possível inativar o cartão</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult InactivateAndReissue([FromBody] InactivateAndReissueCardRequest inactivateAndReissueCardRequest)
        {
            BusinessService.InactivateAndReissueCardRequest businessRequest = _mapper.Map(inactivateAndReissueCardRequest);

            ICardService cardService = _serviceFactory.Create();
            cardService.InactivateAndReissue(businessRequest);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }
    }
}