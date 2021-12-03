using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class CardValidator
    {
        public void Validate(ActivateCardRequest activateCardRequest)
        {
            if (string.IsNullOrEmpty(activateCardRequest.IdentifierCard))
                throw new OsbBusinessException(BusinessExcMsg.EXC0051);

            if (activateCardRequest.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if (activateCardRequest.UserId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0034);
        }

        public void Validate(InactivateAndReissueCardRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if (string.IsNullOrEmpty(request.IdentifierCard))
                throw new OsbBusinessException(BusinessExcMsg.EXC0053);

            if (string.IsNullOrEmpty(request.Pin))
                throw new OsbBusinessException(BusinessExcMsg.EXC0054);

            if (request.Pin.Length != 4)
                throw new OsbBusinessException(BusinessExcMsg.EXC0056);

            if (!Enum.IsDefined(typeof(ReasonCodeCard), request.ReasonCode))
                throw new OsbBusinessException(BusinessExcMsg.EXC0055);
        }

        public void Validate(UpdateCardStatusRequest updateCardStatusRequest)
        {
            if (string.IsNullOrEmpty(updateCardStatusRequest.IdentifierCard))
                throw new OsbBusinessException(BusinessExcMsg.EXC0047);
        }

    }
}