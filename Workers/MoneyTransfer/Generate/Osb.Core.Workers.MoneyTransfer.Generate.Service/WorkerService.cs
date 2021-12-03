using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.MoneyTransfer.Generate
{
    public class WorkerService
    {
        private readonly IMoneyTransferServiceFactory _moneyTransferServiceFactory;
        private readonly Settings _settings;

        public WorkerService(IMoneyTransferServiceFactory moneyTransferServiceFactory, Settings settings)
        {
            _moneyTransferServiceFactory = moneyTransferServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            IMoneyTransferService moneyTransferService = _moneyTransferServiceFactory.Create();
            IEnumerable<BusinessModel.MoneyTransfer> moneyTransferList = moneyTransferService.FindMoneyTransferListByStatus(MoneyTransferStatus.Created);

            foreach (BusinessModel.MoneyTransfer moneyTransferToProcess in moneyTransferList)
            {
                try
                {
                    moneyTransferService.GenerateMoneyTransfer(moneyTransferToProcess);
                }
                catch (Exception)
                {
                    if (moneyTransferToProcess.Attempts >= _settings.Attempts)
                    {
                        UpdateMoneyTransferStatusRequest updateMoneyTransferStatusRequest = new UpdateMoneyTransferStatusRequest()
                        {
                            Identifier = moneyTransferToProcess.Identifier,
                            Status = MoneyTransferStatus.Error
                        };
                        moneyTransferService.UpdateMoneyTransferStatus(updateMoneyTransferStatusRequest);
                    }
                    else
                        moneyTransferService.UpdateMoneyTransferAttempts(moneyTransferToProcess.MoneyTransferId);
                }
            }
        }
    }
}
