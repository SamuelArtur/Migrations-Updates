using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindBankStatementRequest : BaseRequest
    {
        public new string Method { get => "GetAccountEntry"; }
        public string TaxId { get; set; }
        public OperationType? OperationType { get; set; }
        public List<string> Tags { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}