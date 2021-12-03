using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
using Osb.Core.Api.Common.Resources;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Result;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class BoletoPaymentController : ControllerBase
    {
        private readonly BoletoPaymentMapper _mapper;
        private readonly IBoletoPaymentServiceFactory _serviceFactory;

        public BoletoPaymentController(IBoletoPaymentServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapper = new BoletoPaymentMapper();
        }

        /// <summary>
        /// Gera um pagamento.
        /// </summary>
        /// <param name="boletoPaymentRequest">Body da requisição</param>
        /// <returns>Saldo da conta</returns>
        /// <response code="200">Gerar pagamento</response>
        /// <response code="400">Não foi possível gerar pagamento</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] BoletoPaymentRequest boletoPaymentRequest)
        {
            BusinessService.BoletoPaymentRequest businessRequest = _mapper.Map(boletoPaymentRequest);

            IBoletoPaymentService boletoPaymentService = _serviceFactory.Create();
            boletoPaymentService.Save(businessRequest);

            Response response = ResponseMapper.Map(true, null, ApiInfoMsg.ApiInfo0006);
            return Ok(response);
        }

        /// <summary>
        /// Busca informações de pagamento por código de barras na CIP
        /// </summary>
        /// <param name="findInfosPaymentCIPByBarcodeRequest">Body da requisição</param>
        /// <returns>Informaçoes para pagamento do boleto</returns>
        /// <response code="200">Buscar informações para pagamento de boleto por código de barras</response>
        /// <response code="400">Não foi buscar informações do boleto</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindInfosPaymentCIPByBarcode([FromBody] FindInfosPaymentCIPByBarcodeRequest findInfosPaymentCIPByBarcodeRequest)
        {
            BusinessService.FindInfosPaymentCIPByBarcodeRequest businessRequest = _mapper.Map(findInfosPaymentCIPByBarcodeRequest);

            IBoletoPaymentService boletoPayment = _serviceFactory.Create();
            FindInfosPaymentCIPByBarcodeResult findInfosPaymentCIPByBarcodeResult = boletoPayment.FindInfosPaymentCIPByBarcode(businessRequest);

            Response response = ResponseMapper.Map(true, findInfosPaymentCIPByBarcodeResult);
            return Ok(response);
        }

        /// <summary>
        /// Busca informações de boleto por código de barras
        /// </summary>
        /// <param name="findInfosPaymentByBarcodeRequest">Body da requisição</param>
        /// <returns>Informaçoes do boleto</returns>
        /// <response code="200">Buscar informações do boleto por código de barras</response>
        /// <response code="400">Não foi buscar informações do boleto</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindInfosPaymentByBarcode([FromBody] FindInfosPaymentByBarcodeRequest findInfosPaymentByBarcodeRequest)
        {
            BusinessService.FindInfosPaymentByBarcodeRequest businessRequest = _mapper.Map(findInfosPaymentByBarcodeRequest);

            IBoletoPaymentService boletoPayment = _serviceFactory.Create();
            FindInfosPaymentByBarcodeResult paymentsResult = boletoPayment.FindInfosPaymentByBarcode(businessRequest);

            Response response = ResponseMapper.Map(true, paymentsResult);
            return Ok(response);
        }

        /// <summary>
        /// Verifica se o boleto pode ser pago.
        /// </summary>
        /// <param name="verifiyBoletoCanBePaidRequest"></param>
        /// <returns>Retorna se o boleto pode ou não ser pago</returns>
        /// <response code="200">Boleto pode ser pago</response>
        /// <response code="400">Boleto não pode ser pago</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult VerifiyBoletoCanBePaid([FromBody] VerifiyBoletoCanBePaidRequest verifiyBoletoCanBePaidRequest)
        {
            BusinessService.VerifiyBoletoCanBePaidRequest request = _mapper.Map(verifiyBoletoCanBePaidRequest);

            IBoletoPaymentService paymentService = _serviceFactory.Create();
            paymentService.VerifiyBoletoCanBePaid(request);

            Response response = ResponseMapper.Map(true);
            return Ok(response);
        }

        /// <summary>
        /// Apresenta a data esperada para pagamento de boleto.
        /// </summary>
        /// <param name="findExpectedBoletoPaymentDateRequest"></param>
        /// <returns>Retorna a data esperada para pagamento de boleto</returns>
        /// <response code="200">Data esperada de pagamento de boleto</response>
        /// <response code="400">Data não apresentada</response>

        [HttpPost("[action]")]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindExpectedBoletoPaymentDate([FromBody] FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            BusinessService.FindExpectedBoletoPaymentDateRequest request = _mapper.Map(findExpectedBoletoPaymentDateRequest);

            IBoletoPaymentService paymentsService = _serviceFactory.Create();
            FindExpectedBoletoPaymentDateResult findExpectedDateBoletoPaymentResult = paymentsService.FindExpectedBoletoPaymentDate(request);

            Response response = ResponseMapper.Map(true, findExpectedDateBoletoPaymentResult);
            return Ok(response);
        }
    }
}