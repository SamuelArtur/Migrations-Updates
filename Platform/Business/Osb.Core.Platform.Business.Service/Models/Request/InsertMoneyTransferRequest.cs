using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class MoneyTransferRequest : BaseRequest
    {
        public string ToTaxId { get; set; }
        public string ToName { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public decimal Value { get; set; }
        public DateTime TransferDate { get; set; }
        public string Description { get; set; }
    }
}