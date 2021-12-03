using Osb.Core.Api.Application.Models.Request;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class BoletoPaymentMapper
    {
        public BusinessRequest.BoletoPaymentRequest Map(BoletoPaymentRequest boletoPaymentRequest)
        {
            return new BusinessRequest.BoletoPaymentRequest
            {
                UserId = boletoPaymentRequest.UserId,
                AccountId = boletoPaymentRequest.AccountId,
                Name = boletoPaymentRequest.Name,
                TaxId = boletoPaymentRequest.TaxId,

                Bank = boletoPaymentRequest.Bank,
                BankBranch = boletoPaymentRequest.BankBranch,
                BankAccount = boletoPaymentRequest.BankAccount,
                BankAccountDigit = boletoPaymentRequest.BankAccountDigit,

                ReceiverName = boletoPaymentRequest.ReceiverName,
                ReceiverTaxId = boletoPaymentRequest.ReceiverTaxId,
                PayerName = boletoPaymentRequest.ReceiverName,
                PayerTaxId = boletoPaymentRequest.PayerTaxId,
                Barcode = boletoPaymentRequest.Barcode,
                PaymentValue = boletoPaymentRequest.PaymentValue,
                PaymentDate = boletoPaymentRequest.PaymentDate,
                DueDate = boletoPaymentRequest.DueDate,
                DiscountValue = boletoPaymentRequest.DiscountValue,
                Description = boletoPaymentRequest.Description
            };
        }

        public BusinessRequest.FindInfosPaymentCIPByBarcodeRequest Map(FindInfosPaymentCIPByBarcodeRequest findInfosPaymentCIPByBarcodeRequest)
        {
            return new BusinessRequest.FindInfosPaymentCIPByBarcodeRequest
            {
                AccountId = findInfosPaymentCIPByBarcodeRequest.AccountId,
                TaxId = findInfosPaymentCIPByBarcodeRequest.TaxId,
                Barcode = findInfosPaymentCIPByBarcodeRequest.Barcode
            };
        }

        public BusinessRequest.FindInfosPaymentByBarcodeRequest Map(FindInfosPaymentByBarcodeRequest findInfosPaymentByBarcodeRequest)
        {
            return new BusinessRequest.FindInfosPaymentByBarcodeRequest
            {
                AccountId = findInfosPaymentByBarcodeRequest.AccountId,
                Barcode = findInfosPaymentByBarcodeRequest.Barcode
            };
        }

        public BusinessRequest.VerifiyBoletoCanBePaidRequest Map(VerifiyBoletoCanBePaidRequest verifiyBoletoCanBePaidRequest)
        {
            return new BusinessRequest.VerifiyBoletoCanBePaidRequest
            {
                UserId = verifiyBoletoCanBePaidRequest.UserId,
                AccountId = verifiyBoletoCanBePaidRequest.AccountId,
                Barcode = verifiyBoletoCanBePaidRequest.Barcode
            };
        }

        public BusinessRequest.FindExpectedBoletoPaymentDateRequest Map(FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            return new BusinessRequest.FindExpectedBoletoPaymentDateRequest
            {
                AccountId = findExpectedBoletoPaymentDateRequest.AccountId,
                ActualDatePayment = findExpectedBoletoPaymentDateRequest.ActualDatePayment.Value,
                BarCode = findExpectedBoletoPaymentDateRequest.BarCode
            };
        }
    }
}