namespace Osb.Core.Platform.Auth.Service.Models.Result
{
    public class AuthenticateResult
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string TaxId { get; set; }
        public string Token { get; set; }
    }
}