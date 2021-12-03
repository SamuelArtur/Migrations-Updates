using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IAccountRepository
    {
        void Save(Account account);
        void UpdateAccount(long accountId, long companyId, string name, long status, long type, string taxId);
        Account GetByLogin(string login);
        Account GetByTaxId(string taxId, string bank, string bankBranch, string bankAccount, string bankAccountDigit);
        Account GetById(long id);
        Account GetByAccountKey(string accountKey);
        IEnumerable<Account> GetListByLogin(string login);
        IEnumerable<Account> GetListByUserId(long userId);
        IEnumerable<Account> GetByTaxIdAndCompanyId(string taxId, long companyId);
    }
}