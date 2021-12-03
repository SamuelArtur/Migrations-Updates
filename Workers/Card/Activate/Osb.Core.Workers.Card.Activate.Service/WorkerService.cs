using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.Card.Activate
{
    public class WorkerService
    {
        private readonly ICardServiceFactory _cardServiceFactory;
        private readonly Settings _settings;

        public WorkerService(ICardServiceFactory cardServiceFactory, Settings settings)
        {
            _cardServiceFactory = cardServiceFactory;
            _settings = settings;
        }

        public void Activate()
        {
            ICardService cardService = _cardServiceFactory.Create();
            IEnumerable<BusinessModel.ActivateCard> cardList = cardService.FindCardListByStatus(ActivateCardStatus.Created);

            foreach (BusinessModel.ActivateCard cardToProcess in cardList)
            {
                try
                {
                    cardService.ActivateList(cardToProcess);
                }
                catch (Exception)
                {
                    if (cardToProcess.Attempts >= _settings.Attempts)
                    {
                        UpdateCardStatusRequest updateCardStatusRequest = new UpdateCardStatusRequest()
                        {
                            IdentifierCard = cardToProcess.IdentifierCard,
                            Status = ActivateCardStatus.Error
                        };
                        cardService.Update(updateCardStatusRequest);
                    }
                    else
                        cardService.UpdateAttempts(cardToProcess.ActivateCardId);
                }
            }
        }
    }
}
