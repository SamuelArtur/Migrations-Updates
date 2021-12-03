using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateMoneyTransferStatusRequest
    {
        public string Identifier { get; set; }
        public MoneyTransferStatus Status { get; set; }
    }
}