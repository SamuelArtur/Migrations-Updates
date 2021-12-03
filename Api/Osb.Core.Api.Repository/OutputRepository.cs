using System.Collections.Generic;
using System.Threading.Tasks;
using Osb.Core.Api.Entity;
using Osb.Core.Infrastructure.Data.Repository;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;


namespace Osb.Core.Api.Repository
{
    public class OutputRepository : IOutputRepository
    {
        private readonly IDbContext<Output> _context;

        public OutputRepository(IDbContext<Output> context)
        {
            _context = context;
        }

        public void InsertOutputLog(string response)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramResponse"] = response,

            };

            _context.ExecuteWithNoResult("InsertOutputLog", parameters);
            
        }
    }
}
