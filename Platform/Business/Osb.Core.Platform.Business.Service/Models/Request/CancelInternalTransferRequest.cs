namespace Osb.Core.Platform.Business.Service.Models.Request
{
  public class CancelInternalTransferRequest : BaseRequest
  {
    public long? ExternalIdentifier { get; set; }
  }
}