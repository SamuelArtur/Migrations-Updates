namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class CancelMoneyTransferRequest : BaseRequest
    {
        public string ExternalIdentifier { get; set; }
    }
}