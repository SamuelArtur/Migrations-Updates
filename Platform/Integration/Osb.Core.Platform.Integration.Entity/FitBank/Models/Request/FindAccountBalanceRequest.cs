using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindAccountBalanceRequest : BaseRequest
    {
        public new string Method { get => "GetAccountEntry"; }

        public string TaxId { get; set; }
    }
}   