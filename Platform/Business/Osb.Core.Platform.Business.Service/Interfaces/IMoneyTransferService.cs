using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IMoneyTransferService
    {
        void Save(MoneyTransferRequest findMoneyTransferRequest);
        FindExpectedTransferDateResult FindExpectedTransferDate(FindExpectedTransferDateRequest findExpectedTransferDateRequest);
        IEnumerable<MoneyTransfer> FindMoneyTransferListByStatus(MoneyTransferStatus status);
        void GenerateMoneyTransfer(MoneyTransfer moneyTransfer);
        void UpdateMoneyTransferStatus(UpdateMoneyTransferStatusRequest updateMoneyTransferStatusRequest);
        void UpdateMoneyTransferAttempts(long moneyTransferId);
        void Update(UpdateMoneyTransferRequest updateMoneyTransferRequest);
        void CancelMoneyTransfer(CancelMoneyTransferRequest cancelMoneyTransferRequest);
        void CancelMoneyTransfer(MoneyTransfer moneyTransfer);
    }
}