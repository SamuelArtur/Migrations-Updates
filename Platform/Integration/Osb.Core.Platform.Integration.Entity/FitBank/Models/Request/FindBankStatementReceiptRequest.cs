using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindBankStatementReceiptRequest : BaseRequest
    {
        public new string Method { get; set; }
        public string ExternalIdentifier { get; set; }
    }
}