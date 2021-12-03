using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class BoletoPaymentRepository : IBoletoPaymentRepository
    {
        private readonly IDbContext<BoletoPayment> _context;

        public BoletoPaymentRepository(IDbContext<BoletoPayment> context)
        {
            this._context = context;
        }

        public void Save(BoletoPayment boletoPayment, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = boletoPayment.UserId,
                ["paramAccountId"] = boletoPayment.AccountId,
                ["paramName"] = boletoPayment.Name,
                ["paramTaxId"] = boletoPayment.TaxId,
                ["paramReceiverName"] = boletoPayment.ReceiverName,
                ["paramReceiverTaxId"] = boletoPayment.ReceiverTaxId,
                ["paramPayerName"] = boletoPayment.PayerName,
                ["paramPayerTaxId"] = boletoPayment.PayerTaxId,
                ["paramOperationType"] = boletoPayment.OperationType,
                ["paramStatus"] = boletoPayment.Status,
                ["paramBarcode"] = boletoPayment.Barcode,
                ["paramPaymentValue"] = boletoPayment.PaymentValue,
                ["paramPaymentDate"] = boletoPayment.PaymentDate,
                ["paramDueDate"] = boletoPayment.DueDate,
                ["paramDiscountValue"] = boletoPayment.DiscountValue,
                ["paramDescription"] = boletoPayment.Description,
                ["paramIdentifier"] = boletoPayment.Identifier
            };

            _context.ExecuteWithNoResult("InsertBoletoPayment", parameters, transactionScope);
        }

        public BoletoPayment GetById(long boletoPaymentId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = boletoPaymentId
            };

            BoletoPayment boletoPayment = _context.ExecuteWithSingleResult("GetBoletoPaymentById", parameters);

            return boletoPayment;
        }

        public BoletoPayment GetByIdentifier(string identifier)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramIdentifier"] = identifier
            };

            BoletoPayment boletoPayment = _context.ExecuteWithSingleResult("GetBoletoPaymentByIdentifier", parameters);
            return boletoPayment;
        }

        public IEnumerable<BoletoPayment> GetListByStatus(BoletoPaymentStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            IEnumerable<BoletoPayment> boletoPayments = _context.ExecuteWithMultipleResults("getboletopaymentbystatus", parameters);

            return boletoPayments;
        }

        public void Update(BoletoPayment boletoPayment)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = boletoPayment.BoletoPaymentId,
                ["paramUpdateUserId"] = boletoPayment.UserId,
                ["paramStatus"] = boletoPayment.Status
            };

            _context.ExecuteWithNoResult("UpdateBoletoPayment", parameters);
        }

        public void UpdateAttempts(long boletoPaymentId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramBoletoPaymentId"] = boletoPaymentId
            };

            _context.ExecuteWithNoResult("updateboletopaymentattempts", parameters);
        }
    }
}