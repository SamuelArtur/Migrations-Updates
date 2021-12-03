using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindMoneyTransferDetailsResponse
    {
        [JsonPropertyName("PrincipalValue")]
        public decimal Value { get; set; }
        
        public string ToName { get; set; }

        [JsonPropertyName("ToTaxNumber")]
        public string ToTaxId { get; set; }

        [JsonPropertyName("PaymentDate")]
        public DateTime? Date { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }
    }
}