using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Business.Util;

namespace Osb.Core.Platform.Business.Service
{
    public class CardService : ICardService
    {
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly CardValidator _validator;
        private readonly CardMapper _mapper;
        private readonly IActivateCardRepositoryFactory _activateCardRepositoryFactory;
        private readonly IInactivateCardRepositoryFactory _inactivateCardRepositoryFactory;
        private readonly ICardServiceFactory _cardIntegrationServiceFactory;
        private readonly ICardServiceFactory _cardServiceFactory;
        private readonly Settings _settings;


        public CardService(
            IAccountRepositoryFactory accountRepositoryFactory,
            IActivateCardRepositoryFactory cardRepositoryFactory,
            ICardServiceFactory cardIntegrationServiceFactory,
            ICardServiceFactory cardServiceFactory,
            IInactivateCardRepositoryFactory inactivateCardRepositoryFactory,
            Settings settings
        )
        {
            _accountRepositoryFactory = accountRepositoryFactory;
            _activateCardRepositoryFactory = cardRepositoryFactory;
            _cardIntegrationServiceFactory = cardIntegrationServiceFactory;
            _cardServiceFactory = cardServiceFactory;
            _inactivateCardRepositoryFactory = inactivateCardRepositoryFactory;
            _mapper = new CardMapper();
            _validator = new CardValidator();
            _settings = settings;
        }

        public void Activate(ActivateCardRequest activateCardRequest)
        {
            _validator.Validate(activateCardRequest);

            IActivateCardRepository activateCardRepository = _activateCardRepositoryFactory.Create();
            ActivateCard card = activateCardRepository.GetByIdentifier(activateCardRequest.IdentifierCard);

            if (card != null && card.Status == ActivateCardStatus.Created)
                throw new OsbBusinessException(BusinessExcMsg.EXC0052);

            ActivateCard activateCard = ActivateCard.Create(
                                                            activateCardRequest.AccountId,
                                                            activateCardRequest.UserId,
                                                            activateCardRequest.IdentifierCard
                                                            );

            activateCardRepository.Save(activateCard);
        }

        public void ActivateList(ActivateCard card)
        {
            IActivateCardRepository activateCardRepository = _activateCardRepositoryFactory.Create();

            IntegrationRequest.ActivateCardRequest integrationRequest = _mapper.Map(card);
            IntegrationService.ICardService cardIntegrationService = _cardIntegrationServiceFactory.Create();

            IntegrationResponse.ActivateCardResponse cardResponse = cardIntegrationService.ActivateCard(integrationRequest);

            if (cardResponse.Status)
                card.Status = ActivateCardStatus.Active;
            else
            {
                if (card.Attempts <= _settings.Attempts)
                    activateCardRepository.UpdateAttempts(card.ActivateCardId);
                else
                    card.Status = ActivateCardStatus.Error;
            }

            activateCardRepository.Update(card);
        }

        public IEnumerable<ActivateCard> FindCardListByStatus(ActivateCardStatus status)
        {
            IActivateCardRepository activateCardRepository = _activateCardRepositoryFactory.Create();
            IEnumerable<ActivateCard> cardList = activateCardRepository.GetListByStatus(status);

            return cardList;
        }

        public void Update(UpdateCardStatusRequest updateCardStatusRequest)
        {
            _validator.Validate(updateCardStatusRequest);

            IActivateCardRepository activateCardRepository = _activateCardRepositoryFactory.Create();
            ActivateCard card = activateCardRepository.GetByIdentifier(updateCardStatusRequest.IdentifierCard);

            card.Status = updateCardStatusRequest.Status;
            activateCardRepository.Update(card);
        }

        public void UpdateAttempts(long cardId)
        {
            IActivateCardRepository cardRepository = _activateCardRepositoryFactory.Create();
            cardRepository.UpdateAttempts(cardId);
        }

        public void InactivateAndReissue(InactivateAndReissueCardRequest inactivateAndReissueCardRequest)
        {
            _validator.Validate(inactivateAndReissueCardRequest);

            string encryptedPin = CardUtil.EncryptPin
            (
                inactivateAndReissueCardRequest.Pin,
                inactivateAndReissueCardRequest.Salt,
                _settings.AesKey,
                _settings.AesIV
            );

            InactivateCard inactivateCard = InactivateCard.Create
            (
                inactivateAndReissueCardRequest.IdentifierCard,
                inactivateAndReissueCardRequest.AccountId,
                encryptedPin,
                inactivateAndReissueCardRequest.Salt,
                inactivateAndReissueCardRequest.ReasonCode,
                inactivateAndReissueCardRequest.UserId
            );

            IInactivateCardRepository inactivateCardRepository = _inactivateCardRepositoryFactory.Create();
            inactivateCardRepository.Save(inactivateCard);
        }
    }
}