using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindBankStatementRequest
    {
        public string TaxId { get; set; }
        public long AccountId { get; set; }
        public OperationType? OperationType { get; set; }
        public List<string> Tags { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
    }
}