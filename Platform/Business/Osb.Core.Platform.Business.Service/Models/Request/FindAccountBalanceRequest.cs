namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindAccountBalanceRequest
    {
        public string TaxId { get; set; }
        public long AccountId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
    }
}