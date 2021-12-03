using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateCardStatusRequest
    {
        public string IdentifierCard { get; set; }
        public ActivateCardStatus Status { get; set; }
    }
}