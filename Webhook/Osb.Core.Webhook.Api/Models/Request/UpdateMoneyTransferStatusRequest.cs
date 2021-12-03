using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class UpdateMoneyTransferStatusRequest
    {
        public string Identifier { get; set; }
        public MoneyTransferStatus Status { get; set; }
    }
}