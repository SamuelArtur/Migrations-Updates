using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class HashCodeValidator
    {
        public void Validate(GenerateHashCodeRequest generateHashCodeRequest)
        {
            if (generateHashCodeRequest.AccountId == 0)
                throw new OsbBusinessException(string.Format(BusinessExcMsg.EXC0004));

            if (string.IsNullOrEmpty(generateHashCodeRequest.Identifier))
                throw new OsbBusinessException(string.Format(BusinessExcMsg.EXC0042));
        }

        public void Validate(ReadHashCodeRequest readHashCodeRequest)
        {
            if (string.IsNullOrEmpty(readHashCodeRequest.HashCode))
                throw new OsbBusinessException(string.Format(BusinessExcMsg.EXC0031));
        }
    }
}