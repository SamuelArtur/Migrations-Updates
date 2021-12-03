using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface IAccountService
    {
        FindAccountBalanceResponse FindAccountBalance(FindAccountBalanceRequest getBalanceRequest);
        FindBankStatementResponse FindBankStatement(FindBankStatementRequest findBankStatementRequest);
        FindMoneyTransferDetailsResponse FindMoneyTransferDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindMoneyTransferReceiptResponse FindMoneyTransferReceipt(FindBankStatementReceiptRequest findBankStatementReceiptRequest);
        FindInternalTransferDetailsResponse FindInternalTransferDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindInternalTransferReceiptResponse FindInternalTransferReceipt(FindBankStatementReceiptRequest findBankStatementReceiptRequest);
        FindBankStatementMonthlySummaryResponse FindBankStatementMonthlySummary(FindBankStatementMonthlySummaryRequest findBankStatementMonthlySummaryRequest);
    }
}