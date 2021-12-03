using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Result;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class BoletoPaymentMapper
    {
        public IntegrationRequest.FindInfosPaymentCIPByBarcodeRequest Map(Models.Request.FindInfosPaymentCIPByBarcodeRequest findInfosPaymentCIPByBarcodeRequest)
        {
            return new IntegrationRequest.FindInfosPaymentCIPByBarcodeRequest
            {
                AccountId = findInfosPaymentCIPByBarcodeRequest.AccountId,
                TaxId = findInfosPaymentCIPByBarcodeRequest.TaxId,
                BarCode = findInfosPaymentCIPByBarcodeRequest.Barcode
            };
        }

        public IntegrationRequest.BoletoPaymentRequest Map(BoletoPayment boletoPayment, Account account)
        {
            return new IntegrationRequest.BoletoPaymentRequest
            {
                UserId = boletoPayment.UserId,
                AccountId = boletoPayment.AccountId,
                Name = boletoPayment.Name,
                TaxId = boletoPayment.TaxId,
                Bank = account.Bank,
                BankBranch = account.BankBranch,
                BankAccount = account.BankAccount,
                BankAccountDigit = account.BankAccountDigit,
                ReceiverName = boletoPayment.ReceiverName,
                ReceiverTaxId = boletoPayment.ReceiverTaxId,
                PayerName = boletoPayment.PayerName,
                PayerTaxId = boletoPayment.PayerTaxId,
                Barcode = boletoPayment.Barcode,
                PaymentValue = boletoPayment.PaymentValue,
                PaymentDate = boletoPayment.PaymentDate,
                DueDate = boletoPayment.DueDate,
                DiscountValue = boletoPayment.DiscountValue,
                Description = boletoPayment.Description,
                Identifier = boletoPayment.Identifier
            };
        }

        public FindInfosPaymentCIPByBarcodeResult Map(IntegrationResponse.FindInfosPaymentCIPByBarcodeResponse response)
        {
            return new FindInfosPaymentCIPByBarcodeResult
            {
                ReceiverTaxId = response.ReceiverTaxId,
                ReceiverName = response.ReceiverName,
                PayerTaxId = response.PayerTaxId,
                PayerName = response.PayerName,
                PaymentValue = response.PaymentValue,
                PaymentDate = response.PaymentDate,
                DueDate = response.DueDate,
                DiscountValue = response.DiscountValue,
                FineValue = response.FineValue
            };
        }

        public IntegrationRequest.VerifiyBoletoCanBePaidRequest Map(BusinessRequest.VerifiyBoletoCanBePaidRequest verifiyBoletoCanBePaidRequest)
        {
            return new IntegrationRequest.VerifiyBoletoCanBePaidRequest
            {
                AccountId = verifiyBoletoCanBePaidRequest.AccountId,
                Barcode = verifiyBoletoCanBePaidRequest.Barcode
            };
        }

        public VerifiyBoletoCanBePaidResult Map(IntegrationResponse.VerifiyBoletoCanBePaidResponse verifiyBoletoCanBePaidResponse)
        {
            return new VerifiyBoletoCanBePaidResult
            {
                CanBePaid = verifiyBoletoCanBePaidResponse.CanBePaid
            };
        }

        public IntegrationRequest.FindInfosPaymentByBarcodeRequest Map(Models.Request.FindInfosPaymentByBarcodeRequest findInfosPaymentByBarcodeRequest)
        {
            return new IntegrationRequest.FindInfosPaymentByBarcodeRequest
            {
                AccountId = findInfosPaymentByBarcodeRequest.AccountId,
                Barcode = findInfosPaymentByBarcodeRequest.Barcode
            };
        }

        public FindInfosPaymentByBarcodeResult Map(IntegrationResponse.FindInfosPaymentByBarcodeReponse response)
        {
            return new FindInfosPaymentByBarcodeResult
            {
                DigitableLine = response.DigitableLine,
                Barcode = response.Barcode,
                BankCode = response.BankCode,
                BankName = response.BankName,
                Value = response.Value,
                ConcessionaireName = response.ConcessionaireName,
                ConcessionaireCode = response.ConcessionaireCode
            };
        }

        public IntegrationRequest.FindExpectedBoletoPaymentDateRequest Map(BusinessRequest.FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            return new IntegrationRequest.FindExpectedBoletoPaymentDateRequest
            {
                AccountId = findExpectedBoletoPaymentDateRequest.AccountId,
                ActualDatePayment = findExpectedBoletoPaymentDateRequest.ActualDatePayment.Value,
                BarCode = findExpectedBoletoPaymentDateRequest.BarCode
            };
        }

        public FindExpectedBoletoPaymentDateResult Map(IntegrationResponse.FindExpectedBoletoPaymentDateResponse findExpectedBoletoPaymentDateResponse)
        {
            return new FindExpectedBoletoPaymentDateResult
            {
                ExpectedBoletoPaymentDate = findExpectedBoletoPaymentDateResponse.ExpectedBoletoPaymentDate
            };
        }
    }
}