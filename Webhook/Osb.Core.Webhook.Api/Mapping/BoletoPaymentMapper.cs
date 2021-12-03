using Osb.Core.Webhook.Api.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class BoletoPaymentMapper
    {
        public BusinessService.UpdateBoletoPaymentStatusRequest Map(UpdateBoletoPaymentStatusRequest updateBoletoPaymentRequest)
        {
            return new BusinessService.UpdateBoletoPaymentStatusRequest
            {
                Identifier = updateBoletoPaymentRequest.Identifier,
                Status = updateBoletoPaymentRequest.Status,
                UserId = updateBoletoPaymentRequest.UserId,
            };
        }

    }
}