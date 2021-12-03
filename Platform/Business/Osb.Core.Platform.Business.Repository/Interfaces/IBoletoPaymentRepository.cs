using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IBoletoPaymentRepository
    {
         void Save(BoletoPayment boletoPayment, TransactionScope transactionScope = null);
        BoletoPayment GetById(long boletoPaymentId);
        BoletoPayment GetByIdentifier(string identifier);
        IEnumerable<BoletoPayment> GetListByStatus (BoletoPaymentStatus status);
        void Update(BoletoPayment boletoPayment);
        void UpdateAttempts(long boletoPaymentId);
    }
}