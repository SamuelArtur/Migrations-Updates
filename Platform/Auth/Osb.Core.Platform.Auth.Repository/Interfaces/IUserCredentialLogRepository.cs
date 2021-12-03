using System;
using System.Threading.Tasks;


namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IUserCredentialLogRepository
    {
        void Save(string login, long? UserId, DateTime logDate, DateTime creationDate);
    }
}
