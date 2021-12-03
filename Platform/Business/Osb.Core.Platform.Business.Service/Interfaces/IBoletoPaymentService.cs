using System.Collections.Generic;
using System.Threading.Tasks;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IBoletoPaymentService
    {
        void Save(BoletoPaymentRequest boletoPaymentRequest);
        void GenerateBoletoPayment(BoletoPayment boletoPayment);
        void VerifiyBoletoCanBePaid(VerifiyBoletoCanBePaidRequest verifiyBoletoCanBePaidRequest);
        IEnumerable<BoletoPayment> FindBoletoPaymentListByStatus(BoletoPaymentStatus status);
        FindInfosPaymentCIPByBarcodeResult FindInfosPaymentCIPByBarcode(FindInfosPaymentCIPByBarcodeRequest findInfosPaymentByBarcodeRequest);
        FindInfosPaymentByBarcodeResult FindInfosPaymentByBarcode(FindInfosPaymentByBarcodeRequest findInfosBarcodeRequest);
        void UpdateBoletoPaymentStatus(UpdateBoletoPaymentStatusRequest updateBoletoPaymentStatusRequest);
        void UpdateBoletoPaymentAttempts(long boletoPaymentId);
        FindExpectedBoletoPaymentDateResult FindExpectedBoletoPaymentDate(FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest);
    }
}