using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IAuthorizationTokenRepository
    {
        void Save(AuthorizationToken token);
        AuthorizationToken GetByUserIdAndAccountId(long userId, long accountId);
        void UpdateAttempts(long authorizationTokenId);
        void Update(AuthorizationToken authorizationToken, long updateUserId);
        void UnauthorizeTokensByUserIdAndAccountId(long userId, long accountId);

    }
}