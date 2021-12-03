using System.Collections.Generic;
using System.Threading.Tasks;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IHashCodeRepository
    {
        void Save(HashCode saveHashCode);
        
    }
} 