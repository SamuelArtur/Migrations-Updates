using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using System.Linq;
using Osb.Core.Platform.Business.Service.Models.Result;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class InternalTransferMapper
    {
        public IntegrationRequest.InternalTransferRequest Map(Account fromAccount, Account toAccount, InternalTransfer internalTransfer, IEnumerable<OperationTag> operationTags)
        {
            return new IntegrationRequest.InternalTransferRequest
            {
                AccountId = fromAccount.AccountId,
                FromTaxNumber = fromAccount.TaxId,
                FromBank = fromAccount.Bank,
                FromBankBranch = fromAccount.BankBranch,
                FromBankAccount = fromAccount.BankAccount,
                FromBankAccountDigit = fromAccount.BankAccountDigit,
                ToTaxNumber = toAccount.TaxId,
                ToBank = toAccount.Bank,
                ToBankBranch = toAccount.BankBranch,
                ToBankAccount = toAccount.BankAccount,
                ToBankAccountDigit = toAccount.BankAccountDigit,
                Value = internalTransfer.TransferValue,
                TransferDate = internalTransfer.TransferDate,
                Identifier = internalTransfer.Identifier,
                Description = internalTransfer.Description,
                Tags = operationTags.Select((OperationTag) => OperationTag.Tag).ToList()
            };
        }

        public IntegrationRequest.CancelInternalTransferRequest Map(InternalTransfer internalTransfer)
        {
            return new IntegrationRequest.CancelInternalTransferRequest
            {
                AccountId = internalTransfer.FromAccountId,
                DocumentNumber = internalTransfer.ExternalIdentifier.ToString()
            };
        }

        public InternalTransferResult Map(string message)
        {
            return new InternalTransferResult
            {
                Message = message
            };
        }

        public IntegrationRequest.FindPendingInternalTransferRequest Map(FindPendingInternalTransferRequest findPendingInternalTransferRequest)
        {
            return new IntegrationRequest.FindPendingInternalTransferRequest
            {
                AccountId = findPendingInternalTransferRequest.AccountId,
                Name = findPendingInternalTransferRequest.Name,
                TaxNumber = findPendingInternalTransferRequest.TaxId,
                VerificationCode = findPendingInternalTransferRequest.VerificationCode,
                PhoneNumber = findPendingInternalTransferRequest.PhoneNumber
            };
        }

        public FindPendingInternalTransferResult Map(FindPendingInternalTransferResponse findPendingInternalTransferResponse)
        {
            return new FindPendingInternalTransferResult
            {
                Message = findPendingInternalTransferResponse.Message,
                PhoneNumber = findPendingInternalTransferResponse.PhoneNumber,
                TransferValue = findPendingInternalTransferResponse.TransferValue,
                PendingInternalTransferIds = findPendingInternalTransferResponse.PendingInternalTransferIds
            };
        }
    }
}