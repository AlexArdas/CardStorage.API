using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateCard(string suit, int value, int cardDeckId)
        {
            if (!IsValidCardDeckId(value))
            {
                throw new ArgumentException("Неверный ID колоды. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            if (!IsValidSuit(suit))
            {
                throw new ArgumentException("Неверная масть. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }

            if (!IsValidCardValue(cardDeckId))
            {
                throw new ArgumentException("Неверное значение карты. Пожалуйста проверьте правильность введеных данных и повторите попытку");
            }
        }
        public static bool IsValidSuit(string suit)
        {
            return !string.IsNullOrEmpty(suit) && (suit == "Hearts" || suit == "Diamonds" || suit == "Clubs" || suit == "Spades");
        }

        public static bool IsValidCardValue(int value)
        {
            return value >= 2 && value <= 13;
        }
        public static bool IsValidCardDeckId(int cardDeckId)
        {
            return cardDeckId > 0;
        }

    }
}
