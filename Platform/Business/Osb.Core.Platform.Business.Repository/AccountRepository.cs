using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbContext<Account> _context;

        public AccountRepository(IDbContext<Account> context)
        {
            this._context = context;
        }

        public void Save(Account account)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = account.CompanyId,
                ["paramName"] = account.Name,
                ["paramTaxId"] = account.TaxId,
                ["paramType"] = account.Type,
                ["paramStatus"] = account.Status,
                ["paramSubAccountId"] = account.SubAccountId,
            };

            _context.ExecuteWithNoResult("InsertAccount", parameters);
        }

        public Account GetById(long id)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = id
            };

            Account account = _context.ExecuteWithSingleResult("GetAccountById", parameters);
            return account;
        }

        public Account GetByLogin(string login)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login
            };

            Account account = _context.ExecuteWithSingleResult("GetAccountByLogin", parameters);
            return account;
        }

        public Account GetByTaxId(string taxId, string bank, string bankBranch, string bankAccount, string bankAccountDigit)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramTaxId"] = taxId,
                ["paramBank"] = bank,
                ["paramBankBranch"] = bankBranch,
                ["paramBankAccount"] = bankAccount,
                ["paramBankAccountDigit"] = bankAccountDigit,
            };

            Account account = _context.ExecuteWithSingleResult("GetAccountByTaxId", parameters);
            return account;
        }

        public IEnumerable<Account> GetListByLogin(string login)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login
            };

            IEnumerable<Account> account = _context.ExecuteWithMultipleResults("GetAccountListByLogin", parameters);
            return account;
        }

        public IEnumerable<Account> GetListByUserId(long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId
            };

            IEnumerable<Account> account = _context.ExecuteWithMultipleResults("GetAccountListByUserId", parameters);
            return account;
        }

        public void UpdateAccount(long accountId, long companyId, string name, long status, long type, string taxId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId,
                ["paramCompanyId"] = companyId,
                ["paramName"] = name,
                ["paramStatus"] = status,
                ["paramType"] = type,
                ["paramTaxId"] = taxId
            };

            _context.ExecuteWithNoResult("UpdateAccount", parameters);
        }

        public Account GetByAccountKey(string accountKey)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountKey"] = accountKey
            };

            Account account = _context.ExecuteWithSingleResult("GetAccountByAccountKey", parameters);

            return account;
        }

        public IEnumerable<Account> GetByTaxIdAndCompanyId(string taxId, long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramTaxId"] = taxId,
                ["paramCompanyId"] = companyId
            };

            IEnumerable<Account> accounts = _context.ExecuteWithMultipleResults("GetAccountsByTaxIdAndCompanyId", parameters);

            return accounts;
        }
    }
}