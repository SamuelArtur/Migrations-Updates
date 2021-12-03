using System;
using System.ComponentModel.DataAnnotations;

namespace Osb.Core.Api.Application.Models.Request
{
    public class BoletoPaymentRequest
    {
        public long UserId { get; set; }
        public long AccountId { get; set; }  
        [Required]      
        public string Name { get; set; }   
        [Required]     
        public string TaxId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }

        public string ReceiverName { get; set; }
 
        public string ReceiverTaxId { get; set; }
 
        public string PayerName { get; set; }      
 
        public string PayerTaxId { get; set; }
 
        [Required] 
        public string Barcode { get; set; }
 
        [Required] 
        public decimal PaymentValue { get; set; }
 
        [Required] 
        public DateTime PaymentDate { get; set; }
 
        [Required] 
        public DateTime DueDate { get; set; }
 
        [Required] 
        public decimal DiscountValue { get; set; }
        public string Description { get; set; }
    }
}