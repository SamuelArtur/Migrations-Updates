using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
  public interface IInternalTransferRepository
  {
    void Save(InternalTransfer internalTransfer, TransactionScope transactionScope = null);
    void Update(InternalTransfer internalTransfer);
    void UpdateStatus(long? internalTransferId, long externalIdentifier, InternalTransferStatus status);
    void UpdateStatus(string identifier, InternalTransferStatus status);
    InternalTransfer GetById(long internalTransferId);
    IEnumerable<InternalTransfer> GetByStatus(InternalTransferStatus status, long? loadValue = null);
    void UpdateAttempts(long internalTransferId);
    InternalTransfer GetByExternalIdentifier(long externalIdentifier);
  }
}