using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Api.Application.Models.Request
{
    public class InactivateAndReissueCardRequest : BaseRequest
    {
        public string IdentifierCard { get; set; }
        public string Pin { get; set; }
        public ReasonCodeCard ReasonCode { get; set; }
    }
}