using System.ComponentModel.DataAnnotations;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindInfosPaymentByBarcodeRequest
    {
        [Required]
        public long AccountId { get; set; }
        
        [Required]
        public string Barcode { get; set; }
    }
}