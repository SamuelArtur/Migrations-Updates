using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByLogin(string login);
        User GetById(long userId);
        void InsertUser(string login, string name, string email, string cellphone);
        void UpdateUser(long userId, string login, string name, string email, string cellphone);
    }
}