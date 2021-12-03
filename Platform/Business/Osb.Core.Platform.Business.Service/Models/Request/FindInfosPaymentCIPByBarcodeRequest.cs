namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindInfosPaymentCIPByBarcodeRequest
    {
        public long AccountId { get; set; }
        public string TaxId { get; set; }
        public string Barcode { get; set; }
    }
}