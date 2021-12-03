namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class ValidateAuthorizationTokenRequest
    {
       public string Code { get; set; }
       public long UserId { get; set; }
       public long AccountId { get; set; }
    }
}