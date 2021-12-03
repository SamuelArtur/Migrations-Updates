namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class VerifiyBoletoCanBePaidRequest
    {
        public long UserId { get; set; }
        public long AccountId { get; set; }
        public string Barcode { get; set; }
    }
}