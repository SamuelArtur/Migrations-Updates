using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly IDbContext<UserAccount> _context;

        public UserAccountRepository(IDbContext<UserAccount> context)
        {
            this._context = context;
        }

        public void InsertUserAccount(long accountId, long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId,
                ["paramUserId"]= userId

            };

            _context.ExecuteWithNoResult("InsertUserAccount", parameters);
        }
    }
}