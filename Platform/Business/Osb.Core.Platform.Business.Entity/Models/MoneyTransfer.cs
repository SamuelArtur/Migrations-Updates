using System;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class MoneyTransfer : BaseEntity
    {
        public long MoneyTransferId { get; set; }
        public string Identifier { get; set; }
        public long FromAccountId { get; set; }
        public string ToTaxId { get; set; }
        public string ToName { get; set; }
        public long BankingDataId { get; set; }
        public decimal TransferValue { get; set; }
        public DateTime TransferDate { get; set; }
        public MoneyTransferStatus Status { get; set; }
        public string Description { get; set; }
        public string ExternalIdentifier { get; set; }
        public long Attempts { get; set; }

        public static MoneyTransfer Create(long accountId, string toTaxId, string toName, long bankingDataId, decimal transferValue, DateTime transferDate, MoneyTransferStatus status, string description)
        {
            return new MoneyTransfer
            {
                FromAccountId = accountId,
                Identifier = DateTime.Now.Ticks.ToString(),
                ToTaxId = toTaxId,
                ToName = toName,
                BankingDataId = bankingDataId,
                TransferValue = transferValue,
                TransferDate = transferDate,
                Status = status,
                Description = description
            };
        }
    }
}