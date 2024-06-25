using CardStorage.Domain.Enum;
using Domain.Enum;

namespace Domain.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public CardValue Value { get; set; }
        public CardSuit Suit { get; set; }
        public int Order { get; set; }
        public int CardDeckId { get; set; }
    }
}
