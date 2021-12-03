using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IAccountService
    {
        void Save(AccountRequest accountRequest);
        FindAccountDashboardResult FindAccountDashboard(FindAccountDashboardRequest findAccountDashboardRequest);
        FindAccountBalanceResult FindAccountBalance(FindAccountBalanceRequest findAccountBalanceRequest);
        FindBankStatementResult FindBankStatement(FindBankStatementRequest findBankStatementRequest);
        FindBankStatementDetailsResult FindBankStatementDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindBankStatementReceiptResult FindBankStatementReceipt(FindBankStatementReceiptRequest findBankStatementReceiptRequest);
        FindBankStatementMonthlySummaryResult FindBankStatementMonthlySummary(FindBankStatementMonthlySummaryRequest findBankStatementMonthlySummaryRequest);
        FindAccountListResult FindAccountListByUserId(long userId);
        FindAccountListResult FindAccountListByLogin(FindAccountListByLoginRequest findAccountListByLoginRequest);
        FindAccountListResult FindAccountListByTaxId(FindAccountListByTaxIdRequest findAccountByTaxIdRequest);

    }
}