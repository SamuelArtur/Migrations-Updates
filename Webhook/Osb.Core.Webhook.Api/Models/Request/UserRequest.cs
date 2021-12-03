using System;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class UserRequest
    {
        public string TaxNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountTaxNumber { get; set; }
        public string Name  { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public long Status { get; set; }
        public long Type { get; set; }
        public string UserTaxNumber { get; set; }
        public long EventType { get; set; }
        public long BusinessUnitId { get; set; }
    }
}