using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Workers.BoletoPayment.Generate
{
    public class WorkerService
    {
        private readonly IBoletoPaymentServiceFactory _boletoPaymentServiceFactory;
        private readonly Settings _settings;
        
        public WorkerService(IBoletoPaymentServiceFactory boletoPaymentServiceFactory,Settings settings)
        {
            _boletoPaymentServiceFactory = boletoPaymentServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            IBoletoPaymentService boletoPaymentService = _boletoPaymentServiceFactory.Create();
            IEnumerable<BusinessModel.BoletoPayment> boletoPayments = boletoPaymentService.FindBoletoPaymentListByStatus(BoletoPaymentStatus.Created);

            foreach (BusinessModel.BoletoPayment boletoPayment in boletoPayments)
            {
                try
                {
                    boletoPaymentService.GenerateBoletoPayment(boletoPayment);
                }
                catch(Exception)
                {
                    if (boletoPayment.Attempts >= _settings.Attempts)
                    {
                        UpdateBoletoPaymentStatusRequest updateBoletoPaymentStatusRequest = new UpdateBoletoPaymentStatusRequest(){
                            Identifier = boletoPayment.Identifier,
                            Status = BoletoPaymentStatus.Error
                        };
                        boletoPaymentService.UpdateBoletoPaymentStatus(updateBoletoPaymentStatusRequest);
                    }
                    else
                        boletoPaymentService.UpdateBoletoPaymentAttempts(boletoPayment.BoletoPaymentId);
                }
            }
        }
    }
}