using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class Operation : BaseEntity
    {
        public long OperationId { get; set; }
        public OperationType OperationType { get; set; }

        public static Operation Create(long userId)
        {
            return new Operation
            {
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}