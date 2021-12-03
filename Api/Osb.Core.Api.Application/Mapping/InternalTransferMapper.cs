using System.Text.RegularExpressions;
using Osb.Core.Api.Application.Models.Request;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
  public class InternalTransferMapper
  {

    public BusinessRequest.InternalTransferRequest Map(InternalTransferRequest internalTransferRequest)
    {
      return new BusinessRequest.InternalTransferRequest
      {
        AccountId = internalTransferRequest.AccountId,
        UserId = internalTransferRequest.UserId,
        ToTaxId = internalTransferRequest.ToTaxId,
        AccountKey = internalTransferRequest.AccountKey,
        TransferValue = internalTransferRequest.TransferValue,
        TransferDate = internalTransferRequest.TransferDate,
        Tags = internalTransferRequest.Tags,
        Description = internalTransferRequest.Description,
        Bank = internalTransferRequest.Bank,
        BankBranch = internalTransferRequest.BankBranch,
        BankAccount = internalTransferRequest.BankAccount,
        BankAccountDigit = internalTransferRequest.BankAccountDigit
      };
    }

    public BusinessRequest.FindPendingInternalTransferRequest Map(FindPendingInternalTransferRequest getPendingInternalTransferRequest)
    {
      return new BusinessRequest.FindPendingInternalTransferRequest
      {
        AccountId = getPendingInternalTransferRequest.AccountId,
        UserId = getPendingInternalTransferRequest.UserId,
        Name = getPendingInternalTransferRequest.Name,
        TaxId = RemoveMaskFromTaxId(getPendingInternalTransferRequest.TaxId),
        VerificationCode = getPendingInternalTransferRequest.VerificationCode,
        PhoneNumber = getPendingInternalTransferRequest.PhoneNumber
      };
    }

    public BusinessRequest.UpdateInternalTransferRequest Map(UpdateInternalTransferRequest updateInternalTransferRequest)
    {
      return new BusinessRequest.UpdateInternalTransferRequest
      {
        InternalTransferId = updateInternalTransferRequest.InternalTransferId,
        Status = updateInternalTransferRequest.Status,
        UserId = updateInternalTransferRequest.UserId,
        AccountId = updateInternalTransferRequest.AccountId
      };
    }

    public BusinessRequest.CancelInternalTransferRequest Map(CancelInternalTransferRequest cancelInternalTransferRequest)
    {
      return new BusinessRequest.CancelInternalTransferRequest
      {
        AccountId = cancelInternalTransferRequest.AccountId,
        ExternalIdentifier = cancelInternalTransferRequest.ExternalIdentifier,
        UserId = cancelInternalTransferRequest.UserId
      };
    }

    private string RemoveMaskFromTaxId(string taxIdWithMask)
    {
      return Regex.Replace(taxIdWithMask, @"[^\d]+", "");
    }
  }
}