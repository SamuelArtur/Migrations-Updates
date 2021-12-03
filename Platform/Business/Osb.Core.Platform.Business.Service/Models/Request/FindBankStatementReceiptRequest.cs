using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindBankStatementReceiptRequest
    {
        public long? AccountId { get; set; }     
        public string ExternalIdentifier { get; set; }
        public OperationType OperationType  { get; set; }
    }
}