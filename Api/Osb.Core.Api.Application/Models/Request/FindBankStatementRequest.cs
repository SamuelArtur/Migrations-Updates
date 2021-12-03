using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindBankStatementRequest : BaseRequest
    {
        public string TaxId { get; set; }
        public OperationType? OperationType { get; set; }
        public List<string> Tags { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}