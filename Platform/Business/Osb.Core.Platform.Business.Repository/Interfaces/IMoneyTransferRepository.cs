using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IMoneyTransferRepository
    {

        MoneyTransfer Save(MoneyTransfer moneyTransfer, TransactionScope transactionScope = null);
        MoneyTransfer GetById(long moneyTransferId);
        MoneyTransfer GetByIdentifier(string identifier);
        IEnumerable<MoneyTransfer> GetByStatus(MoneyTransferStatus status, long? limit = null);
        void Update(MoneyTransfer moneyTransfer);
        void UpdateAttempts(long moneyTransferId);
        MoneyTransfer GetByExternalIdentifier(string externalIdentifier);
    }
}