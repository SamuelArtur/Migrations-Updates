using System;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindInfosPaymentByBarcodeResult
    {
        public string DigitableLine { get; set; }

        public string Barcode { get; set; }

        public DateTime? DueDate { get; set; }

        public string BankCode { get; set; }

        public string BankName { get; set; }

        public decimal Value { get; set; }

        public string ConcessionaireName { get; set; }

        public string ConcessionaireCode { get; set; }
    }
}