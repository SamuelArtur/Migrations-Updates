using System;
using System.Collections.Generic;
using System.Linq;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Validators
{
  public class InternalTransferValidator
  {
    public void Validate(InternalTransferRequest internalTransferRequest)
    {
      if (internalTransferRequest.TransferDate.Date < DateTime.Today)
        throw new OsbBusinessException(BusinessExcMsg.EXC0008);
    }

    public void Validate(CancelInternalTransferRequest cancelInternalTransferRequest)
    {
      if (cancelInternalTransferRequest.ExternalIdentifier == 0)
        throw new OsbBusinessException(BusinessExcMsg.EXC0001);

      if (cancelInternalTransferRequest.UserId == 0)
        throw new OsbBusinessException(BusinessExcMsg.EXC0036);

      if (cancelInternalTransferRequest.AccountId == 0)
        throw new OsbBusinessException(BusinessExcMsg.EXC0004);
    }

    public void Validate(UpdateInternalTransferStatusRequest internalTransferStatusUpdateRequest)
    {
      if (string.IsNullOrEmpty(internalTransferStatusUpdateRequest.Identifier))
        throw new OsbBusinessException(BusinessExcMsg.EXC0011);

      if (internalTransferStatusUpdateRequest.Status < InternalTransferStatus.Registered || internalTransferStatusUpdateRequest.Status > InternalTransferStatus.Error)
        throw new OsbBusinessException(BusinessExcMsg.EXC0012);
    }

    public void Validate(UpdateInternalTransferRequest updateInternalTransferRequest)
    {
      if (!Enum.IsDefined<InternalTransferStatus>(updateInternalTransferRequest.Status))
        throw new OsbBusinessException(BusinessExcMsg.EXC0031);

      if (updateInternalTransferRequest.InternalTransferId == null)
        throw new OsbBusinessException(BusinessExcMsg.EXC0033);
    }

    public void Validate(FindPendingInternalTransferRequest findPendingInternalTransferRequest)
    {

      if (findPendingInternalTransferRequest.AccountId == 0)
        throw new OsbBusinessException(BusinessExcMsg.EXC0004);

      if (findPendingInternalTransferRequest.UserId == 0)
        throw new OsbBusinessException(BusinessExcMsg.EXC0036);

      if (string.IsNullOrEmpty(findPendingInternalTransferRequest.Name))
        throw new OsbBusinessException(BusinessExcMsg.EXC0024);

      if (string.IsNullOrEmpty(findPendingInternalTransferRequest.TaxId))
        throw new OsbBusinessException(BusinessExcMsg.EXC0005);

      if (string.IsNullOrEmpty(findPendingInternalTransferRequest.VerificationCode) && string.IsNullOrEmpty(findPendingInternalTransferRequest.PhoneNumber))
        throw new OsbBusinessException(BusinessExcMsg.EXC0039);

    }
  }
}