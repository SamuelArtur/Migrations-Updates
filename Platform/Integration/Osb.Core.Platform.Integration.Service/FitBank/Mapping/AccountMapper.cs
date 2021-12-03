using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Mapping;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class AccountMapper : Mapper
    {
        public ExternalRequest Map(
            FindAccountBalanceRequest getBalanceRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                getBalanceRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = getBalanceRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = getBalanceRequest.TaxId,
                    OnlyBalance = true
                }
            };
        }

        public ExternalRequest Map(FindBankStatementRequest findBankStatementRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findBankStatementRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findBankStatementRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    StartDate = findBankStatementRequest.StartDate,
                    EndDate = findBankStatementRequest.EndDate,
                    OperationType = findBankStatementRequest.OperationType,
                    Tags = findBankStatementRequest.Tags,
                    TaxNumber = findBankStatementRequest.TaxId
                }
            };
        }


        public ExternalRequest Map(FindBankStatementDetailsRequest findBankStatementDetailsRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), findBankStatementDetailsRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findBankStatementDetailsRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    DocumentNumber = findBankStatementDetailsRequest.ExternalIdentifier
                }
            };
        }

        public ExternalRequest Map(FindBankStatementReceiptRequest findBankStatementReceiptRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), findBankStatementReceiptRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findBankStatementReceiptRequest.Method,
                    DocumentNumber = findBankStatementReceiptRequest.ExternalIdentifier,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId
                }
            };
        }

        public ExternalRequest Map(FindBankStatementMonthlySummaryRequest findMonthlyAccountMovementsRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), findMonthlyAccountMovementsRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new 
                {
                    Method = findMonthlyAccountMovementsRequest.Method,
                    TaxNumber = findMonthlyAccountMovementsRequest.TaxId,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    Bank = findMonthlyAccountMovementsRequest.Bank,
                    BankBranch = findMonthlyAccountMovementsRequest.BankBranch,
                    BankAccount = findMonthlyAccountMovementsRequest.BankAccount,
                    BankAccountDigit = findMonthlyAccountMovementsRequest.BankAccountDigit,
                    DateMonthly = findMonthlyAccountMovementsRequest.DateMonthly
                }
            };
        }

        public FindBankStatementMonthlySummaryResponse Map(ExternalFindBankStatementMonthlySummaryResponse externalFindMonthlyAccountMovementsResponse)
        {
            return new FindBankStatementMonthlySummaryResponse{
                MoneyInputValue = externalFindMonthlyAccountMovementsResponse.FinancesMonthly.MoneyInputValue,
                MoneyOutputValue = externalFindMonthlyAccountMovementsResponse.FinancesMonthly.MoneyOutputValue
            };
        }
    }
}