using Osb.Core.Webhook.Api.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class InternalTransferMapper
    {
        public BusinessService.UpdateInternalTransferStatusRequest Map(UpdateInternalTransferStatusRequest updateinternalTransferStatusRequest)
        {
            return new BusinessService.UpdateInternalTransferStatusRequest
            {
                Identifier = updateinternalTransferStatusRequest.Identifier,
                Status = updateinternalTransferStatusRequest.Status
            };
        }

    }
}