using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.InternalTransfer.Generate
{
    public class WorkerService
    {
        private readonly IInternalTransferServiceFactory _internalTransferServiceFactory;
        private readonly Settings _settings;

        public WorkerService(IInternalTransferServiceFactory internalTransferServiceFactory, Settings settings)
        {
            _internalTransferServiceFactory = internalTransferServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            IInternalTransferService internalTransferService = _internalTransferServiceFactory.Create();
            IEnumerable<BusinessModel.InternalTransfer> internalTransferList = internalTransferService.FindInternalTransferListByStatus(InternalTransferStatus.Created);

            foreach (BusinessModel.InternalTransfer internalTransferToProcess in internalTransferList)
            {
                try
                {
                    internalTransferService.GenerateInternalTransfer(internalTransferToProcess.InternalTransferId);
                }
                catch (Exception)
                {
                    if (internalTransferToProcess.Attempts > _settings.Attempts)
                    {
                        UpdateInternalTransferStatusRequest updateInternalTransferStatusRequest = new UpdateInternalTransferStatusRequest(){
                            Identifier = internalTransferToProcess.Identifier,
                            Status = InternalTransferStatus.Error
                        };
                        internalTransferService.UpdateInternalTransferStatus(updateInternalTransferStatusRequest);
                    }
                    else
                        internalTransferService.UpdateInternalTransferAttempts(internalTransferToProcess.InternalTransferId);
                }
            }
        }
    }
}
