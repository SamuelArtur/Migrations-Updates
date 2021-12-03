using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IInternalTransferService
    {
        void Save(InternalTransferRequest internalTransferRequest);
        void GenerateInternalTransfer(long internalTransferId);
        IEnumerable<InternalTransfer> FindInternalTransferListByStatus(InternalTransferStatus status);
        void UpdateInternalTransferStatus(UpdateInternalTransferStatusRequest updateinternalTransferStatusRequest);
        void CancelInternalTransfer(CancelInternalTransferRequest cancelInternalTransferRequest);
        void CancelInternalTransfer(long id);
        void UpdateInternalTransferAttempts(long internalTransferId);
        void UpdateStatus(UpdateInternalTransferRequest updateInternalTransferRequest);
        FindPendingInternalTransferResult FindPendingInternalTransfer(FindPendingInternalTransferRequest findPendingInternalTransferRequest);
    }
}