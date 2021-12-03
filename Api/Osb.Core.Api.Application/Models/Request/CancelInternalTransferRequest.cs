
namespace Osb.Core.Api.Application.Models.Request
{
  public class CancelInternalTransferRequest : BaseRequest
  {
    public long ExternalIdentifier { get; set; }
  }
}