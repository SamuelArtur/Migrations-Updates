using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class SubAccount : BaseEntity
    {
        public long SubAccountId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }

        public static SubAccount Create(string bank, string bankBranch, string bankAccount, string bankAccountDigit)
        {
            return new SubAccount
            {
                Bank = bank,
                BankBranch = bankBranch,
                BankAccount = bankAccount,
                BankAccountDigit = bankAccountDigit
            };
        }
    }
}