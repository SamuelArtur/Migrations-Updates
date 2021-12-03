using System;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class AccountRequest
    {
        public long PartnerId { get; set; }
        public long BusinessUnitId { get; set; }
        public string TaxNumber { get; set; }
        public string Name { get; set; }
        public long AccountConditionType { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public int AccountStatus { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string AccountKey { get; set; }
    }
}