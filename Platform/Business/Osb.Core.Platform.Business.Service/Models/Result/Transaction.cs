using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class Transaction
    {
        public string Title { get; set; }
        public decimal Value { get; set; }
        public string Establishment { get; set; }
        public string ExternalIdentifier { get; set; }
        public OperationType OperationType { get; set; }
    }
}