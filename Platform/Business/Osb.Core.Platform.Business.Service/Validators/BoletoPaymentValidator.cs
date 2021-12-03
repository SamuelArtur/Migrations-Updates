using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class BoletoPaymentValidator
    {
        public void Validate(FindExpectedBoletoPaymentDateRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if (!request.ActualDatePayment.HasValue)
                throw new OsbBusinessException(BusinessExcMsg.EXC0048);

            if (string.IsNullOrEmpty(request.BarCode))
                throw new OsbBusinessException(BusinessExcMsg.EXC0047);
        }
    }
}