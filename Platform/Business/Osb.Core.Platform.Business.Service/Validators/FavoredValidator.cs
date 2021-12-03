using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class FavoredValidator
    {
        public void Validate(FindFavoredListByAccountIdRequest request)
        {
            if(request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if(request.UserId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0013);
        }

        public void Validate(FavoredRequest favoredRequest)
        {
            if(favoredRequest.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);
            
            if(string.IsNullOrEmpty(favoredRequest.TaxId))
                throw new OsbBusinessException(BusinessExcMsg.EXC0005);
            
            if(favoredRequest.TaxId.Length != 11 & favoredRequest.TaxId.Length != 14)
                throw new OsbBusinessException(BusinessExcMsg.EXC0040);

            if(string.IsNullOrEmpty(favoredRequest.Name))
                throw new OsbBusinessException(BusinessExcMsg.EXC0024);

            if(!Enum.IsDefined(typeof(OperationType), favoredRequest.Type))
                throw new OsbBusinessException(BusinessExcMsg.EXC0012);

            if(favoredRequest.UserId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0036);
        }
    }
}