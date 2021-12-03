using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Repository
{
    public class SubAccountRepository : ISubAccountRepository
    {
        private readonly IDbContext<SubAccount> _context;

        public SubAccountRepository(IDbContext<SubAccount> context)
        {
            this._context = context;
        }

        public SubAccount Save(SubAccount bankingData)
        {
            var parameters = new Dictionary<string, dynamic> {
                ["paramBank"] = bankingData.Bank,
                ["paramBankBranch"] = bankingData.BankBranch,
                ["paramBankAccount"] = bankingData.BankAccount,
                ["paramBankAccountDigit"] = bankingData.BankAccountDigit,
            };

            SubAccount bankingDataResult = _context.ExecuteWithSingleResult("InsertSubAccount", parameters);
            return bankingDataResult;
        }
    }
}