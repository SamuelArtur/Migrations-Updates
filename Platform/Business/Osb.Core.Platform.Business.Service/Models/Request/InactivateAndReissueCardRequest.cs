using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class InactivateAndReissueCardRequest : BaseRequest
    {
        public string IdentifierCard { get; set; }
        public string Pin { get; set; }
        public ReasonCodeCard ReasonCode { get; set; }
        public string Salt { get; set; }
    }
}