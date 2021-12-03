namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IUserAccountRepository
    {
        void InsertUserAccount(long accountId, long userId);
    }
}