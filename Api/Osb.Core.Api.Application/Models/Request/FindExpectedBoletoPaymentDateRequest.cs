using System;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindExpectedBoletoPaymentDateRequest : BaseRequest
    {
        public DateTime? ActualDatePayment { get; set; }
        public string BarCode { get; set; }
    }
}