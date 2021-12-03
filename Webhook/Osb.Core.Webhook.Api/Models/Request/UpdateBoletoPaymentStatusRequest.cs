using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class UpdateBoletoPaymentStatusRequest
    {
        public string Identifier { get; set; }
        public BoletoPaymentStatus Status { get; set; }
        public long UserId { get; set; }
    }
}