using System.ComponentModel.DataAnnotations;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindBankStatementDetailsRequest : BaseRequest
    {
        public string ExternalIdentifier { get; set; }
        public OperationType OperationType { get; set; }
    }
}