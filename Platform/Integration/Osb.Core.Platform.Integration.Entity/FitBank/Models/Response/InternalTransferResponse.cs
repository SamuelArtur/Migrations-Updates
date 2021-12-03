using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class InternalTransferResponse
    {
        [JsonPropertyName("DocumentNumber")]
        public long ExternalIdentifier { get; set; }
    }
}