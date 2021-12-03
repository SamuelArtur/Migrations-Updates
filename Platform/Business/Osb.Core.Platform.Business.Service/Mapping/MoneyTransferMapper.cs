using Osb.Core.Platform.Business.Service.Models.Result;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class MoneyTransferMapper
    {
        public IntegrationRequest.FindExpectedTransferDateRequest Map(Models.Request.FindExpectedTransferDateRequest request)
        {
            return new IntegrationRequest.FindExpectedTransferDateRequest
            {
                AccountId = request.AccountId,
                ActualDateTransfer = request.ActualDateTransfer,
                BankCode = request.BankCode,
                AccountType = request.AccountType,
                CustomFormatDate = request.CustomFormatDate
            };
        }

        public FindExpectedTransferDateResult Map(FindExpectedTransferDateResponse response)
        {
            return new FindExpectedTransferDateResult
            {
                ExpectedTransferDate = response.ExpectedTransferDate
            };
        }

        public IntegrationRequest.MoneyTransferRequest Map(MoneyTransfer moneyTransfer, Account account, BankingData bankingData)
        {
            return new IntegrationRequest.MoneyTransferRequest()
            {
                AccountId = moneyTransfer.FromAccountId,
                Identifier = moneyTransfer.Identifier,
                FromTaxId = account.TaxId,
                ToTaxId = moneyTransfer.ToTaxId,
                ToName = moneyTransfer.ToName,
                Bank = bankingData.Bank,
                BankBranch = bankingData.BankBranch,
                BankAccount = bankingData.BankAccount,
                BankAccountDigit = bankingData.BankAccountDigit,
                Value = moneyTransfer.TransferValue,
                PaymentDate = moneyTransfer.TransferDate,
                Description = moneyTransfer.Description
            };
        }

        public CancelMoneyTransferRequest Map(MoneyTransfer moneyTransferRequest)
        {
            return new CancelMoneyTransferRequest
            {
                AccountId = moneyTransferRequest.FromAccountId,
                DocumentNumber = moneyTransferRequest.ExternalIdentifier,
            };
        }
    }
}
