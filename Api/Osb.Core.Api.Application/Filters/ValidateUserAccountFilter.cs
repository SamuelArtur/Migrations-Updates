using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Osb.Core.Platform.Business.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;

namespace Osb.Core.Api.Application.Filters
{
    /// <summary>
    /// Classe que valida se foram enviados a ApiVersion e Token na requisição.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">Versão da API ou Token não encontrados</exception>
    public class ValidateUserAccountFilter : ActionFilterAttribute
    {

        private readonly IAccountServiceFactory _accountServiceFactory;

        public ValidateUserAccountFilter(IAccountServiceFactory serviceFactory)
        {
            _accountServiceFactory = serviceFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Request.Body.Position = 0;

            using (var reader = new System.IO.StreamReader(context.HttpContext.Request.Body))
            {
                string body = reader.ReadToEndAsync().Result;
                BaseRequest baseRequest = JsonSerializer.Deserialize<BaseRequest>(body);
                if (baseRequest.UserId.Equals(default(long)))
                    throw new OsbBusinessException(BusinessExcMsg.EXC0045);
                
                if (baseRequest.AccountId.Equals(default(long)))
                    throw new OsbBusinessException(BusinessExcMsg.EXC0004);
                
                ClaimsIdentity securityToken = context.HttpContext.User.Identity as ClaimsIdentity;
                if (securityToken != null)
                {                    
                    long userId =  long.Parse(securityToken.FindFirst(ClaimTypes.NameIdentifier).Value);
                    if (userId != baseRequest.UserId)
                        throw new OsbBusinessException(BusinessExcMsg.EXC0044);

                    IAccountService accountService = _accountServiceFactory.Create();
                    FindAccountListResult findAccountListResult = accountService.FindAccountListByUserId(userId);
                    if(!findAccountListResult.AccountList.ToList().Any(acc => acc.AccountId == baseRequest.AccountId))
                        throw new OsbBusinessException(BusinessExcMsg.EXC0046);
                }
            }
        }
    }
}