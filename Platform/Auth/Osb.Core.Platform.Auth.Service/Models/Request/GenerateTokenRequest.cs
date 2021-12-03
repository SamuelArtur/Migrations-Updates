namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class AuthorizationTokenRequest
    {
        public long UserId { get; set; }
        
        public long AccountId { get; set; }
    }
}