using CardStorage.Common.Request;
using CardStorage.Domain.Enum;
using Domain.Enum;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;

namespace CardStorage.BL.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateCard(int suit, int value, int cardDeckId, ICardDeckRepository cardDeckRepository)
        {
            if (!IsValidCardDeckId(cardDeckId, cardDeckRepository))
            {
                throw new BadRequestException("Неверный ID колоды. Пожалуйста, проверьте правильность введенных данных и повторите попытку.");
            }

            if (!IsValidSuit(suit))
            {
                throw new BadRequestException("Неверная масть. Пожалуйста, проверьте правильность введенных данных и повторите попытку.");
            }

            if (!IsValidCardValue(value))
            {
                throw new BadRequestException("Неверное значение карты. Пожалуйста, проверьте правильность введенных данных и повторите попытку.");
            }
        }

        public static bool IsValidSuit(int suit)
        {
            return Enum.IsDefined(typeof(CardSuit), suit);
        }

        public static bool IsValidCardValue(int value)
        {
            return value >= 2 && value <= 14;
        }

        public static bool IsValidCardDeckId(int cardDeckId, ICardDeckRepository cardDeckRepository)
        {
            var cardDeck = cardDeckRepository.GetCardDeck(cardDeckId);
            return cardDeck != null;
        }

        public static bool IsValidCardId(int cardId, int cardDeckId, ICardRepository cardRepository, ICardDeckRepository cardDeckRepository)
        {
            var cardDeck = cardDeckRepository.GetCardDeck(cardDeckId);
            return cardDeck != null && cardRepository.GetCard(cardDeck, cardId) != null;
        }

        public static void ValidateCardsInDeck(IEnumerable<AddCardRequest> cards)
        {
            foreach (var card in cards)
            {
                if (!Enum.IsDefined(typeof(CardValue), card.Value))
                {
                    throw new BadRequestException($"Неверное значение карты {card.Value}. Значение карты должно быть от 2 до 13.");
                }

                if (!Enum.IsDefined(typeof(CardSuit), card.Suit))
                {
                    throw new BadRequestException($"Неверная масть карты {card.Suit}. Укажите одну из допустимых мастей: Hearts, Diamonds, Clubs, Spades.");
                }

                if (card.Order <= 0)
                {
                    throw new BadRequestException($"Неверное значение Order. Order должен быть больше 0.");
                }
            }
        }
    }
}
