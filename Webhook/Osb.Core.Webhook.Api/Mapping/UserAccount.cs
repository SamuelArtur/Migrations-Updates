using System.Text.RegularExpressions;
using Osb.Core.Webhook.Api.Models.Request;
using AuthService = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class UserMapper
    {
        public AuthService.UserRequest Map(UserRequest userRequest)
        {
            return new AuthService.UserRequest
            {
                TaxId = RemoveMaskFromTaxId(userRequest.TaxNumber),
                AccountName = userRequest.AccountName,
                AccountTaxId = userRequest.AccountTaxNumber,
                Name = userRequest.Name,
                Email = userRequest.Email,
                CellPhone = userRequest.CellPhone,
                Status = userRequest.Status,
                Type = userRequest.Type,
                UserTaxId = userRequest.UserTaxNumber,
                EventType = userRequest.EventType,
                CompanyId = userRequest.BusinessUnitId
            };
        }

        private string RemoveMaskFromTaxId(string taxIdWithMask)
        {
            return Regex.Replace(taxIdWithMask, @"[^\d]+", "");
        }
    }
}