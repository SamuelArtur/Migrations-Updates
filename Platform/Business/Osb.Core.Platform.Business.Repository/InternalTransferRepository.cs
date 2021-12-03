using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Repository
{
  public class InternalTransferRepository : IInternalTransferRepository
  {
    private readonly IDbContext<InternalTransfer> _context;

    public InternalTransferRepository(IDbContext<InternalTransfer> context)
    {
      this._context = context;
    }

    public void Save(InternalTransfer internalTransfer, TransactionScope transactionScope = null)
    {
      var parameters = new Dictionary<string, dynamic>
      {
        ["paramIdentifier"] = internalTransfer.Identifier,
        ["paramOperationId"] = internalTransfer.OperationId,
        ["paramFromAccountId"] = internalTransfer.FromAccountId,
        ["paramToAccountId"] = internalTransfer.ToAccountId,
        ["paramTransferValue"] = internalTransfer.TransferValue,
        ["paramTransferDate"] = internalTransfer.TransferDate,
        ["paramStatus"] = internalTransfer.Status,
        ["paramDescription"] = internalTransfer.Description,
        ["paramCreationUserId"] = internalTransfer.CreationUserId,
        ["paramUpdateUserId"] = internalTransfer.UpdateUserId
      };

      _context.ExecuteWithNoResult("InsertInternalTransfer", parameters, transactionScope);
    }

    public void UpdateStatus(long? internalTransferId, long externalIdentifier, InternalTransferStatus status)
    {
      var parameters = new Dictionary<string, dynamic>
      {
        ["paramId"] = internalTransferId,
        ["paramStatus"] = status,
        ["paramExternalIdentifier"] = externalIdentifier
      };

      _context.ExecuteWithNoResult("UpdateInternalTransferStatusToGenerated", parameters);
    }

    public void UpdateStatus(string identifier, InternalTransferStatus transactionStatus)
    {
      var parameters = new Dictionary<string, dynamic>
      {
        ["paramIdentifier"] = identifier,
        ["paramStatus"] = transactionStatus
      };
      _context.ExecuteWithNoResult("UpdateInternalTransferStatusByIdentifier", parameters);
    }

    public InternalTransfer GetById(long internalTransferId)
    {
      var parameters = new Dictionary<string, dynamic>
      {
        ["paramId"] = internalTransferId
      };

      InternalTransfer internalTransfer = _context.ExecuteWithSingleResult("GetInternalTransferById", parameters);

      return internalTransfer;
    }

    public IEnumerable<InternalTransfer> GetByStatus(InternalTransferStatus status, long? limit = null)
    {
      var parameters = new Dictionary<string, dynamic>
      {
        ["paramLimit"] = limit,
        ["paramStatus"] = status
      };

      IEnumerable<InternalTransfer> internalTransferList = _context.ExecuteWithMultipleResults("GetInternalTransferByStatus", parameters);

      return internalTransferList;
    }

    public void UpdateAttempts(long internalTransferId)
    {
      var parameters = new Dictionary<string, dynamic>
      {
        ["paramId"] = internalTransferId
      };
      _context.ExecuteWithNoResult("UpdateInternalTransferAttempts", parameters);
    }

    public void Update(InternalTransfer internalTransfer)
    {
      var parameters = new Dictionary<string, dynamic>
      {
        ["paramId"] = internalTransfer.InternalTransferId,
        ["paramExternalIdentifier"] = internalTransfer.ExternalIdentifier,
        ["paramStatus"] = internalTransfer.Status,
        ["paramUpdateUserId"] = internalTransfer.UpdateUserId,
      };
      _context.ExecuteWithNoResult("UpdateInternalTransfer", parameters);
    }

    public InternalTransfer GetByExternalIdentifier(long externalIdentifier)
    {
      var parameters = new Dictionary<string, dynamic>
      {
        ["paramExternalIdentifier"] = externalIdentifier
      };

      InternalTransfer internalTransfer = _context.ExecuteWithSingleResult("getinternaltransferbyexternalidentifier", parameters);
      return internalTransfer;
    }
  }
}