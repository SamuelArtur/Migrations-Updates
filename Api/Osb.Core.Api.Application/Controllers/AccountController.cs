using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Osb.Core.Api.Application.Filters;
using Osb.Core.Api.Application.Mapping;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Models.Response;
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
    [Route("[controller]/[action]")]
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
        /// Busca dados do usuário para montar o dashboard.
        /// </summary>
        /// <param name="findAccountDashboardRequest">Body da requisição</param>
        /// <returns>Saldo da conta</returns>
        /// <response code="200">Retona saldo da conta especificada</response>
        /// <response code="400">Conta não encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindAccountDashboard([FromBody] FindAccountDashboardRequest findAccountDashboardRequest)
        {
            BusinessService.FindAccountDashboardRequest businessRequest = _mapper.Map(findAccountDashboardRequest);

            IAccountService accountService = _serviceFactory.Create();
            FindAccountDashboardResult result = accountService.FindAccountDashboard(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary> 
        /// Busca a listagem de contas existentes de um usuário específico.
        /// </summary>
        /// <param name="findAcountListByLoginRequest">Body da requisição</param>
        /// <returns>Lista de contas</returns>
        /// <response code="200">Lista de contas</response>
        /// <response code="400">Lista de contas não encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindAcountListByLogin([FromBody] FindAcountListByLoginRequest findAcountListByLoginRequest)
        {
            BusinessService.FindAccountListByLoginRequest businessRequest = _mapper.Map(findAcountListByLoginRequest);

            IAccountService accountService = _serviceFactory.Create();
            FindAccountListResult result = accountService.FindAccountListByLogin(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Busca o saldo da conta de um usuário.
        /// </summary>
        /// <param name="findAccountBalanceRequest">Body da requisição</param>
        /// <returns>Saldo da conta</returns>
        /// <response code="200">Retona saldo da conta especificada</response>
        /// <response code="400">Conta não encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindAccountBalance([FromBody] FindAccountBalanceRequest findAccountBalanceRequest)
        {
            BusinessService.FindAccountBalanceRequest businessRequest = _mapper.Map(findAccountBalanceRequest);

            IAccountService accountService = _serviceFactory.Create();
            FindAccountBalanceResult result = accountService.FindAccountBalance(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Busca o extrato da conta de um usuário.
        /// </summary>
        /// <param name="findBankStatementRequest">Body da requisição</param>
        /// <returns>Extrato da conta</returns>
        /// <response code="200">Extrato da conta</response>
        /// <response code="400">Conta não encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindBankStatement([FromBody] FindBankStatementRequest findBankStatementRequest)
        {
            BusinessService.FindBankStatementRequest businessRequest = _mapper.Map(findBankStatementRequest);

            IAccountService accountService = _serviceFactory.Create();
            FindBankStatementResult result = accountService.FindBankStatement(businessRequest);

            Response response = ResponseMapper.Map(true, result);

            return Ok(response);
        }

        /// <summary>
        /// Busca os detalhes do extrato da conta de um usuário.
        /// </summary>
        /// <param name="findBankStatementDetailsRequest">Body da requisição</param>
        /// <returns>Detalhes do extrato da conta</returns>
        /// <response code="200">Detalhes do extrato da conta</response>
        /// <response code="400">Conta não encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindBankStatementDetails([FromBody] FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            BusinessService.FindBankStatementDetailsRequest businessRequest = _mapper.Map(findBankStatementDetailsRequest);

            IAccountService accountService = _serviceFactory.Create();
            FindBankStatementDetailsResult result = accountService.FindBankStatementDetails(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Apresenta o comprovante de transação.
        /// </summary>
        /// <param name="findBankStatementReceiptRequest"></param>
        /// <returns>Retorna o comprovante da transação</returns>
        /// <response code="200"></response>
        /// <response code="400"></response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindBankStatementReceipt([FromBody] FindBankStatementReceiptRequest findBankStatementReceiptRequest)
        {
            BusinessService.FindBankStatementReceiptRequest businessRequest = _mapper.Map(findBankStatementReceiptRequest);

            IAccountService accountService = _serviceFactory.Create();
            FindBankStatementReceiptResult result = accountService.FindBankStatementReceipt(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Exibe os valores de entrada e saída da conta no mês.
        /// </summary>
        /// <param name="findBankStatementMonthlySummaryRequest"></param>
        /// <returns>Retorna valores de entrada e saída da conta no mês</returns>
        /// <response code="200"></response>
        /// <response code="400"></response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindBankStatementMonthlySummary([FromBody] FindBankStatementMonthlySummaryRequest findBankStatementMonthlySummaryRequest)
        {
            BusinessService.FindBankStatementMonthlySummaryRequest businessRequest = _mapper.Map(findBankStatementMonthlySummaryRequest);

            IAccountService accountService = _serviceFactory.Create();
            FindBankStatementMonthlySummaryResult result = accountService.FindBankStatementMonthlySummary(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }

        /// <summary>
        /// Busca dados da conta bancária
        /// </summary>
        /// <param name="findAccountListByTaxIdRequest"></param>
        /// <returns>Retorna dados da conta bancária</returns>
        /// <response code="200">Retorna dados de conta bancária</response>
        /// <response code="400">Nenhuma conta foi encontrada</response>

        [HttpPost]
        [ValidateCredentialRequestFilter]
        [TypeFilter(typeof(ValidateUserAccountFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult FindAccountListByTaxId([FromBody] FindAccountListByTaxIdRequest findAccountListByTaxIdRequest)
        {
            BusinessService.FindAccountListByTaxIdRequest businessRequest = _mapper.Map(findAccountListByTaxIdRequest);

            IAccountService accountService = _serviceFactory.Create();
            FindAccountListResult result = accountService.FindAccountListByTaxId(businessRequest);

            Response response = ResponseMapper.Map(true, result);
            return Ok(response);
        }
    }
}