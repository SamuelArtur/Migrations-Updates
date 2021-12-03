using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class Account : BaseEntity
    {
        public long AccountId { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public long Type { get; set; }
        public long Status { get; set; }
        public long? SubAccountId { get; set; }
        public string AccountKey { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }

        public static Account Create(long companyId, string name, string taxId, long type, long status, string accountKey, long? subAccountId)
        {
            return new Account
            {
                CompanyId = companyId,
                Name = name,
                TaxId = taxId,
                Type = type,
                Status = status,
                AccountKey = accountKey,
                SubAccountId = subAccountId
            };
        }
    }
}