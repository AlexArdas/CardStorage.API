using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class CardDeckRepository : ICardDeckRepository
    {
        private readonly List<CardDeck> _cardDecks = new List<CardDeck>();

        public CardDeck GetCardDeck(int cardDeckId)
        {
            return _cardDecks.FirstOrDefault(cd => cd.Id == cardDeckId);
        }

        public IEnumerable<CardDeck> GetAllDecks()
        {
            return _cardDecks;
        }

        public void CreateCardDeck(CardDeck cardDeck)
        {
            cardDeck.Id = _cardDecks.Any() ? _cardDecks.Max(cd => cd.Id) + 1 : 1;
            _cardDecks.Add(cardDeck);
        }

        public void UpdateCardDeck(CardDeck cardDeck)
        {
            var existingCardDeck = GetCardDeck(cardDeck.Id);
            if (existingCardDeck != null)
            {
                existingCardDeck.Name = cardDeck.Name;
            }
        }

        public void DeleteCardDeck(int cardDeckId)
        {
            var cardDeck = GetCardDeck(cardDeckId);
            if (cardDeck != null)
            {
                _cardDecks.Remove(cardDeck);
            }
        }

        public void ShuffleCardDeck(int cardDeckId)
        {
            var cardDeck = GetCardDeck(cardDeckId);
            if (cardDeck != null && cardDeck.Cards != null && cardDeck.Cards.Any())
            {
                var random = new Random();
                cardDeck.Cards = cardDeck.Cards.OrderBy(x => random.Next()).ToList();
                UpdateCardDeck(cardDeck);
            }
        }
    }
}
