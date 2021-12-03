using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateInternalTransferStatusRequest
    {
        public string Identifier { get; set; }
        public InternalTransferStatus Status { get; set; }
    }
}