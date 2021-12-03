using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class Favored : BaseEntity
    {
        public long FavoredId { get; set; }
        public long AccountId { get; set; }
        public string TaxId { get; set; }
        public string Name { get; set; }
        public OperationType Type { get; set; }
        public string BankName { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }

        public static Favored Create(long accountId, string taxId, string name, OperationType type, string bankName, string bank, string bankBranch, string bankAccount, string bankAccountDigit)
        {
            return new Favored
            {
                AccountId = accountId,
                TaxId = taxId,
                Name = name,
                Type = type,
                BankName = bankName,
                Bank = bank,
                BankBranch = bankBranch,
                BankAccount = bankAccount,
                BankAccountDigit = bankAccountDigit
            };
        }
    }
}