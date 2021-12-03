using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Api.Application.Models.Request
{
    public class UpdateMoneyTransferRequest : BaseRequest
    {
        public long? MoneyTransferId { get; set; }
        public MoneyTransferStatus Status { get; set; }
    }
}