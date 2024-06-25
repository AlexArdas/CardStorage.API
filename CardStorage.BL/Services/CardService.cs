using CardStorage.Common.Request;
using CardStorage.Common.Response;
using CardStorage.Domain.Enum;
using Common.Helpers;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;

namespace BL.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICardDeckRepository _cardDeckRepository;

        public CardService(ICardRepository cardRepository, ICardDeckRepository cardDeckRepository)
        {
            _cardRepository = cardRepository;
            _cardDeckRepository = cardDeckRepository;
        }

        public GetCardResponse GetCard(int cardId, int cardDeckId)
        {
            var cardDeck = _cardDeckRepository.GetCardDeck(cardDeckId);
            if (cardDeck == null)
            {
                throw new ArgumentException("Колода не найдена. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            var card = _cardRepository.GetCard(cardDeck, cardId);
            return new GetCardResponse
            {
                CardDeckId = card.CardDeckId,
                Id = card.Id,
                Order = card.Order,
                Suit = card.Suit.ToString(),
                Value = card.Value.ToString(),
            };
        }

        public void AddCard(AddCardRequest card)
        {
            var random = new Random();
            var cardDeck = _cardDeckRepository.GetCardDeck(card.CardDeckId);
            _cardRepository.AddCard(cardDeck,new Card
            {
                Id = random.Next(int.MaxValue),
                CardDeckId = card.CardDeckId,
                Order = card.Order,
                Suit = (CardSuit)card.Suit,
                Value = (CardValue)card.Value,
            });
            _cardDeckRepository.UpdateCardDeck(cardDeck);
        }

        public void UpdateCard(UpdateCardRequest card)
        {
            var cardDeck = _cardDeckRepository.GetCardDeck(card.CardDeckId);
            if (cardDeck != null)
            {
                _cardRepository.UpdateCard(cardDeck, new Card
                {
                    Id = card.Id,
                    Suit = (CardSuit)card.Suit,
                    Value = (CardValue)card.Value,
                });
                _cardDeckRepository.UpdateCardDeck(cardDeck);
            }
            else
            {
                throw new ArgumentException("Такой колоды не существует");
            }
        }

        public void DeleteCard(int cardId, int cardDeckId)
        {
            var cardDeck = _cardDeckRepository.GetCardDeck(cardDeckId);
            if (cardDeck != null)
            {
                _cardRepository.DeleteCard(cardDeck, cardId);
                _cardDeckRepository.UpdateCardDeck(cardDeck);
            }
            else
            {
                throw new ArgumentException("Такой колоды не существует");
            }
        }

        public GetAllCardsInDeckResponse GetAllCardsInDeck(int cardDeckId)
        {
            var cardDeck = _cardDeckRepository.GetCardDeck(cardDeckId);
            var cardResponses = new List<GetCardResponse>();
            if (cardDeck != null)
            {
                var cards = _cardRepository.GetAllCardsInDeck(cardDeck);
                cardResponses = cards.Select(c => new GetCardResponse
                {
                    CardDeckId = c.CardDeckId,
                    Id = c.Id,
                    Order = c.Order,
                    Suit = c.Suit.ToString(),
                    Value = c.Value.ToString(),
                }).ToList();
            }
            return new GetAllCardsInDeckResponse
            {
                Cards = cardResponses
            };
        }
    }
}
