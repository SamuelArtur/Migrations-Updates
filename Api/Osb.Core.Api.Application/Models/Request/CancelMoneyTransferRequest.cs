
namespace Osb.Core.Api.Application.Models.Request
{
    public class CancelMoneyTransferRequest : BaseRequest
    {
        public string ExternalIdentifier { get; set; }
    }
}