using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Repository
{
    public class UserRepository : IUserRepository
    {
        private IDbContext<User> _context;

        public UserRepository(IDbContext<User> context)
        {
            _context = context;
        }

        public User GetUserByLogin(string login)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login
            };

            User user = _context.ExecuteWithSingleResult("GetUserByLogin", parameters);

            return user;
        }

        public User GetById(long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId
            };

            User user = _context.ExecuteWithSingleResult("GetUserById", parameters);

            return user;
        }

        public void InsertUser(string login, string name, string email, string cellphone)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login,
                ["paramName"] = name,
                ["paramMail"] = email,
                ["paramCellPhone"] = cellphone
            };

            _context.ExecuteWithNoResult("InsertUser", parameters);
        }

        public void UpdateUser(long userId, string login, string name, string email, string cellphone)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId,
                ["paramLogin"] = login,
                ["paramName"] = name,
                ["paramMail"] = email,
                ["paramCellPhone"] = cellphone
            };

            _context.ExecuteWithNoResult("UpdateUser", parameters);
        }
    }
}