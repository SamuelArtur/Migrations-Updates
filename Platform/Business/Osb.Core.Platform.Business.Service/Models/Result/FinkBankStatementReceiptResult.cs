using System;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindBankStatementReceiptResult
    {
        public decimal? Value {get; set;}        
        public string ToName {get; set;}
        public string TaxId {get; set;}
        public DateTime? Date  {get; set;}
        public string Description {get; set;}
        public string ControlCode {get; set;}
        public string ProtocolCode  {get; set;}
    }
}