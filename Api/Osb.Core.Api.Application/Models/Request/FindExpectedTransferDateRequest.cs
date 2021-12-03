using System;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindExpectedTransferDateRequest : BaseRequest
    {
        public DateTime ActualTransferDate { get; set; }
        public string BankCode { get; set; }
        public string AccountType { get; set; }
        public bool? CustomFormatDate { get; set; }
    }
}