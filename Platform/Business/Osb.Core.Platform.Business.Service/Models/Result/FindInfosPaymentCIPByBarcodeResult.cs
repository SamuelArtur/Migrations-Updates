using System;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindInfosPaymentCIPByBarcodeResult
    {
        public string ReceiverTaxId { get; set; }
        public string ReceiverName { get; set; }
        public string PayerTaxId { get; set; }
        public string PayerName { get; set; }
        public decimal PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal FineValue { get; set; }    
    }
}