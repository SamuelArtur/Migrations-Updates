using System;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindMoneyTransferReceiptResponse
    {
        [JsonPropertyName("PrincipalValue")]
        public decimal? Value { get; set; }

        [JsonPropertyName("ToName")]
        public string ToName { get; set; }

        [JsonPropertyName("ToTaxNumber")]
        public string TaxId { get; set; }

        [JsonPropertyName("PaymentDate")]
        public DateTime? Date  { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }    

        [JsonPropertyName("PaymentAuthentication")]    
        public string ControlCode { get; set; }   

        [JsonPropertyName("ProtocolId")]         
        public string ProtocolCode  { get; set; }
    }
}