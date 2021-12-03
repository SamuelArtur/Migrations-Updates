using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindBankStatementDetailsRequest
    {
        public string ExternalIdentifier {get; set;}
        public long AccountId { get; set; }
        public OperationType OperationType{get; set;}
    }
}