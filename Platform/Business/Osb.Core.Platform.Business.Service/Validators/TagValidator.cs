using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class TagValidator
    {
        public void Validate(FindSuggestionTagListRequest request)
        {          
            if (request.AccountId.Equals(default(long)))
               throw new OsbBusinessException(BusinessExcMsg.EXC0004);
               
            if(request.TagAmount <= 0)
               throw new OsbBusinessException(BusinessExcMsg.EXC0043); 
        }
    }
}