using System;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindExpectedTransferDateRequest
    {
        public long AccountId { get; set; }
        public DateTime ActualDateTransfer { get; set; }
        public string BankCode { get; set; }
        public string AccountType { get; set; }
        public bool? CustomFormatDate { get; set; }
    }
}