using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class VerifiyBoletoCanBePaidRequest : BaseRequest
    {
        public new string Method { get => "CheckBarcodeCanBePaid"; }
        public string Barcode { get; set; }
    }
}