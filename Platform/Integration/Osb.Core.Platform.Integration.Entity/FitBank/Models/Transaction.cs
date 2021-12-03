using System;
using System.Text.Json.Serialization;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models
{
    public class Transaction
    {
        public string Description { get; set; }
        
        [JsonPropertyName("EntryDate")]
        public DateTime Date { get; set; }
        
        [JsonPropertyName("EntryValue")]
        public decimal Value { get; set; }
        
        [JsonPropertyName("DocumentNumber")]
        public string ExternalIdentifier { get; set; }

        [JsonPropertyName("OperationType")]
        public OperationType OperationType { get; set; }
    }
}