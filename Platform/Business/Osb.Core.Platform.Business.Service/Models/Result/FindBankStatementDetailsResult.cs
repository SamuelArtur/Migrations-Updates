using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindBankStatementDetailsResult
    {
        public decimal? Value { get; set; }
        public string ToName { get; set; }
        public string ToTaxId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public MoneyTransferStatus Status { get; set; }
        public string ExternalIdentifier { get; set; }
    }
}