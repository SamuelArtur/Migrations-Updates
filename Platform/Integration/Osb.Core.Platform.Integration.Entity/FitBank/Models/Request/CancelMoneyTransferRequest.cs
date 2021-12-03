using System;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class CancelMoneyTransferRequest : BaseRequest
    {
        public new string Method { get => "CancelMoneyTransfer"; }
        public string DocumentNumber { get; set; }
    }
}