using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class CancelInternalTransferRequest : BaseRequest
    {
        public new string Method { get => "CancelInternalTransfer"; }
        public string DocumentNumber { get; set; }
    }
}