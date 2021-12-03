using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindBankStatementDetailsResponse
    {
        [JsonPropertyName("Transferencia")]
        public string MoneyTransfer { get; set; }

        [JsonPropertyName("InternalTransfer")]        
        public string InternalTransfer { get; set; }
    }
}