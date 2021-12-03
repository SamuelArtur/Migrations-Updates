using System;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Webhook.Api.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;
namespace Osb.Core.Webhook.Api.Mapping
{
    public class MoneyTransferMapper
    {
        public BusinessService.UpdateMoneyTransferStatusRequest Map(UpdateMoneyTransferStatusRequest moneyTransferOutStatusRequest)
        {
            return new BusinessService.UpdateMoneyTransferStatusRequest
            {
                Identifier = moneyTransferOutStatusRequest.Identifier,
                Status = moneyTransferOutStatusRequest.Status
            };
        }

        private MoneyTransferStatus ConvertStatus(string status)
        {
            MoneyTransferStatus convertedStatus = (MoneyTransferStatus)Enum.Parse(typeof(MoneyTransferStatus), status);

            return convertedStatus;
        }
    }
}