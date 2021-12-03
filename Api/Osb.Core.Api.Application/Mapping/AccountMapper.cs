using System.Text.RegularExpressions;
using Osb.Core.Api.Application.Models.Request;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class AccountMapper
    {
        public BusinessRequest.FindAccountDashboardRequest Map(FindAccountDashboardRequest findAccountDashboardRequest)
        {
            return new BusinessRequest.FindAccountDashboardRequest
            {
                Login = RemoveMaskFromTaxId(findAccountDashboardRequest.Login),
            };
        }

        public BusinessRequest.FindAccountBalanceRequest Map(FindAccountBalanceRequest findAccountBalanceRequest)
        {
            return new BusinessRequest.FindAccountBalanceRequest
            {
                TaxId = RemoveMaskFromTaxId(findAccountBalanceRequest.TaxId),
                AccountId = findAccountBalanceRequest.AccountId
            };
        }

        public BusinessRequest.FindBankStatementRequest Map(FindBankStatementRequest findBankStatementRequest)
        {
            return new BusinessRequest.FindBankStatementRequest
            {
                TaxId = RemoveMaskFromTaxId(findBankStatementRequest.TaxId),
                AccountId = findBankStatementRequest.AccountId,
                StartDate = findBankStatementRequest.StartDate,
                EndDate = findBankStatementRequest.EndDate,
                OperationType = findBankStatementRequest.OperationType,
                Tags = findBankStatementRequest.Tags
            };
        }

        public BusinessRequest.FindAccountListByLoginRequest Map(FindAcountListByLoginRequest findAllAcountsByTaxIdRequest)
        {
            return new BusinessRequest.FindAccountListByLoginRequest
            {
                Login = RemoveMaskFromTaxId(findAllAcountsByTaxIdRequest.Login)
            };
        }

        private string RemoveMaskFromTaxId(string taxIdWithMask)
        {
            return Regex.Replace(taxIdWithMask, @"[^\d]+", "");
        }

        public BusinessRequest.FindBankStatementDetailsRequest Map(FindBankStatementDetailsRequest findBankStatementDetails)
        {
            return new BusinessRequest.FindBankStatementDetailsRequest
            {
                AccountId = findBankStatementDetails.AccountId,
                ExternalIdentifier = findBankStatementDetails.ExternalIdentifier,
                OperationType = findBankStatementDetails.OperationType
            };
        }

        public BusinessRequest.FindBankStatementReceiptRequest Map(FindBankStatementReceiptRequest findBankStatementReceiptRequest)
        {
            return new BusinessRequest.FindBankStatementReceiptRequest
            {
                AccountId = findBankStatementReceiptRequest.AccountId,
                ExternalIdentifier = findBankStatementReceiptRequest.ExternalIdentifier,
                OperationType = findBankStatementReceiptRequest.OperationType
            };
        }

        public BusinessRequest.FindBankStatementMonthlySummaryRequest Map(FindBankStatementMonthlySummaryRequest findMonthlyAccountMovementsRequest)
        {
            return new BusinessRequest.FindBankStatementMonthlySummaryRequest
            {
                UserId = findMonthlyAccountMovementsRequest.UserId,
                AccountId = findMonthlyAccountMovementsRequest.AccountId,
                DateMonthly = findMonthlyAccountMovementsRequest.DateMonthly,
            };
        }

        public BusinessRequest.FindAccountListByTaxIdRequest Map(FindAccountListByTaxIdRequest findAccountDashboardRequest)
        {
            return new BusinessRequest.FindAccountListByTaxIdRequest
            {
                AccountId = findAccountDashboardRequest.AccountId,
                TaxId = RemoveMaskFromTaxId(findAccountDashboardRequest.TaxId)
            };
        }
    }
}