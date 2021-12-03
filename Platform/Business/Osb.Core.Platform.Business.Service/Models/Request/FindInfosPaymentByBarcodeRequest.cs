namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindInfosPaymentByBarcodeRequest
    {
        public long AccountId { get; set; }
        public string Barcode { get; set; }
    }
}