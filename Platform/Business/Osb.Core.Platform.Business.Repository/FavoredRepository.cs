using System;
using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class FavoredRepository : IFavoredRepository
    {
        private readonly IDbContext<Favored> _context;

        public FavoredRepository(IDbContext<Favored> context)
        {
            this._context = context;
        }

        public IEnumerable<Favored> GetByAccountId(long accountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId
            };

            IEnumerable<Favored> favoredList = _context.ExecuteWithMultipleResults("GetFavoredByAccountId", parameters);

            return favoredList;
        }

        public void Save(Favored favored, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = favored.AccountId,
                ["paramTaxId"] = favored.TaxId,
                ["paramName"] = favored.Name,
                ["paramType"] = Convert.ChangeType(favored.Type, favored.Type.GetTypeCode()),
                ["paramBankName"] = favored.BankName,
                ["paramBank"] = favored.Bank,
                ["paramBankBranch"] = favored.BankBranch,
                ["paramBankAccount"] = favored.BankAccount,
                ["paramBankAccountDigit"] = favored.BankAccountDigit,
                ["paramUser"] = favored.UpdateUserId
            };

            _context.ExecuteWithNoResult("InsertFavored", parameters, transactionScope);
        }

        public IEnumerable<Favored> GetFavored(long accountId, string taxId, string bank, string bankBranch, string bankAccount, OperationType type)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId,
                ["paramTaxId"] = taxId,
                ["paramBank"] = bank,
                ["paramBankBranch"] = bankBranch,
                ["paramBankAccount"] = bankAccount,
                ["paramType"] = Convert.ChangeType(type, type.GetTypeCode()),
            };

            IEnumerable<Favored> favoredList = _context.ExecuteWithMultipleResults("GetFavored", parameters);

            return favoredList;
        }
    }
}