using System.Text.RegularExpressions;
using Osb.Core.Webhook.Api.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class AccountMapper
    {
        public BusinessService.AccountRequest Map(AccountRequest accountRequest)
        {
            return new BusinessService.AccountRequest
            {
                CompanyId = accountRequest.BusinessUnitId,
                CompanyAuthenticationId = accountRequest.PartnerId,
                TaxId = RemoveMaskFromTaxId(accountRequest.TaxNumber),
                Name = accountRequest.Name,
                Type = accountRequest.AccountConditionType,
                Status = accountRequest.AccountStatus,
                CreationDate = accountRequest.AccountCreationDate,
                Bank = accountRequest.Bank,
                BankAccount = accountRequest.BankAccount,
                BankAccountDigit = accountRequest.BankAccountDigit,
                BankBranch = accountRequest.BankBranch,
                AccountKey = accountRequest.AccountKey
            };
        }

        private string RemoveMaskFromTaxId(string taxIdWithMask)
        {
            return Regex.Replace(taxIdWithMask, @"[^\d]+", "");
        }
    }
}