using Common.Helpers;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

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

        public Card GetCard(int cardId, int cardDeckId)
        {
            if (!ValidationHelper.IsValidCardDeckId(cardDeckId))
            {
                throw new ArgumentException("Неверный ID колоды. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            var cardDeck = _cardDeckRepository.GetCardDeck(cardDeckId);
            if (cardDeck == null)
            {
                throw new ArgumentException("Колода не найдена. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            return _cardRepository.GetCard(cardDeck, cardId);
        }

        public void AddCard(Card card)
        {
            if (!ValidationHelper.IsValidCardDeckId(card.CardDeckId))
            {
                throw new ArgumentException("Неверный ID колоды. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            if (!ValidationHelper.IsValidCardValue((int)card.Value))
            {
                throw new ArgumentException("Неверное значение карты. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            var cardDeck = _cardDeckRepository.GetCardDeck(card.CardDeckId);
            _cardRepository.AddCard(cardDeck, card);
            _cardDeckRepository.UpdateCardDeck(cardDeck);
        }

        public void UpdateCard(Card card)
        {
            if (!ValidationHelper.IsValidCardDeckId(card.CardDeckId))
            {
                throw new ArgumentException("Неверный ID колоды. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            if (!ValidationHelper.IsValidSuit(card.Suit))
            {
                throw new ArgumentException("Неверная масть. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            if (!ValidationHelper.IsValidCardValue((int)card.Value))
            {
                throw new ArgumentException("Неверное значение карты. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            var cardDeck = _cardDeckRepository.GetCardDeck(card.CardDeckId);
            if (cardDeck != null)
            {
                _cardRepository.UpdateCard(cardDeck, card);
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

        public IEnumerable<Card> GetAllCardsInDeck(int cardDeckId)
        {
            var cardDeck = _cardDeckRepository.GetCardDeck(cardDeckId);
            return cardDeck != null ? _cardRepository.GetAllCardsInDeck(cardDeck) : Enumerable.Empty<Card>();
        }
    }
}
