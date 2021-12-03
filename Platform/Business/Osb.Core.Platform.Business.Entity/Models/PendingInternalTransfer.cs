using System;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class PendingInternalTransfer : BaseEntity
    {
        public string Name { get; set; }

        public string TaxNumber { get; set; }

        public string VerificationCode { get; set; }
        
        public string PhoneNumber { get; set; }

        public static PendingInternalTransfer Create(string name, string taxNumber, string verificationCode, string phoneNumber)
        {
            return new PendingInternalTransfer
            {
                Name = name,
                TaxNumber = taxNumber,
                VerificationCode = verificationCode,
                PhoneNumber = phoneNumber
            };
        }
    }
}