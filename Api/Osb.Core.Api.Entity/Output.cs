using System;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Api.Entity
{
    public class Output : BaseEntity
    {
        public long? OutputId { get; set; }
        public string Response { get; set; }
        public DateTime LogDate { get; set; }
    }
}