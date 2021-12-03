using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindAccountDashboardResult
    {
        public IEnumerable<Account> Accounts { get; set; }
        public decimal Balance { get; set; }
    }
}