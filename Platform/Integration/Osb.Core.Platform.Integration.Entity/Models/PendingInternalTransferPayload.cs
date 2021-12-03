using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.Models
{
    public class PendingInternalTransferPayload
    {
        public decimal TransferValue { get; set; }
        public string PhoneNumber { get; set; }
        public List<long> PendingInternalTransferIds { get; set; }
    }
}