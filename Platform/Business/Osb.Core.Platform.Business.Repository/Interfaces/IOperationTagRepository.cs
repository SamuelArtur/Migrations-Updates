using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;


namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IOperationTagRepository
    {
        OperationTag Save(OperationTag operationTag, TransactionScope transactionScope = null);
        IEnumerable<OperationTag> GetOperationTagsByOperationId(long operationId); 
    }
} 

