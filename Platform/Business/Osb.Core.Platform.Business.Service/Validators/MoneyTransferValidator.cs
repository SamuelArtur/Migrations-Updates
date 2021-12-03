using System;
using System.Collections.Generic;
using System.Linq;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class MoneyTransferValidator
    {
        public void Validate(FindExpectedTransferDateRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if (request.ActualDateTransfer < DateTime.MinValue.AddDays(1))
                throw new OsbBusinessException(BusinessExcMsg.EXC0014);

            if (string.IsNullOrEmpty(request.BankCode))
                throw new OsbBusinessException(BusinessExcMsg.EXC0015);

            if (string.IsNullOrEmpty(request.AccountType))
                throw new OsbBusinessException(BusinessExcMsg.EXC0016);
        }

        // public void Validate(FindMoneyTransferRequest request)
        // {
        //     if (request.FromTaxNumber == "")
        //         throw new OsbBusinessException();

        //     if (request.ToName == "")
        //         throw new OsbBusinessException();

        //     if (request.Bank == "")
        //         throw new OsbBusinessException();

        //     if (request.AccountType == 0)
        //         throw new OsbBusinessException();

        //     if (request.BankBranch == "")
        //         throw new OsbBusinessException();

        //     if (request.BankAccountDigit == "")
        //         throw new OsbBusinessException();

        //     if (request.Value == 0)
        //         throw new OsbBusinessException();

        //     if (request.PaymentDate < DateTime.Now)
        //         throw new OsbBusinessException();

        //     if (request.Description == "")
        //         throw new OsbBusinessException();
        // }

        public void Validate(UpdateMoneyTransferStatusRequest updateMoneyTransferStatusRequest)
        {
            if (string.IsNullOrEmpty(updateMoneyTransferStatusRequest.Identifier))
                throw new OsbBusinessException();

            if (updateMoneyTransferStatusRequest.Status < MoneyTransferStatus.Registered || updateMoneyTransferStatusRequest.Status > MoneyTransferStatus.Error)
                throw new OsbBusinessException();
        }

        public void Validate(MoneyTransferRequest request)
        {
            // if (request.AccountId == 0)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0004);

            // if (request.TaxId == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0001);

            // if (request.ToName == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0002);

            // if (request.Bank == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0003);

            // if (request.AccountType == null)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0005);

            // if (request.BankBranch == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0006);

            // if (request.BankAccountDigit == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0007);

            // if (request.Value <= 0)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0008);

            // if (request.PaymentDate < DateTime.Now)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0009);
        }

        public void Validate(UpdateMoneyTransferRequest updateMoneyTransferRequest)
        {
            if (!Enum.IsDefined<MoneyTransferStatus>(updateMoneyTransferRequest.Status))
                throw new OsbBusinessException(BusinessExcMsg.EXC0031);

            if (updateMoneyTransferRequest.MoneyTransferId == null)
                throw new OsbBusinessException(BusinessExcMsg.EXC0032);
        }

        public void Validate(CancelMoneyTransferRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if (request.UserId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0036);

            if (String.IsNullOrEmpty(request.ExternalIdentifier))
                throw new OsbBusinessException(BusinessExcMsg.EXC0001);
        }
    }
}