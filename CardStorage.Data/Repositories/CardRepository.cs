using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        public Card GetCard(CardDeck cardDeck, int cardId)
        {
            return cardDeck.Cards.FirstOrDefault(c => c.Id == cardId);
        }

        public IEnumerable<Card> GetAllCardsInDeck(CardDeck cardDeck)
        {
            return cardDeck?.Cards.OrderBy(c => c.Order) ?? Enumerable.Empty<Card>();
        }

        public void AddCard(CardDeck cardDeck, Card card)
        {
            card.Id = cardDeck.Cards.Any() ? cardDeck.Cards.Max(c => c.Id) + 1 : 1;
            card.Order = cardDeck.Cards.Count + 1;
            cardDeck.Cards.Add(card);
        }

        public void UpdateCard(CardDeck cardDeck, Card card)
        {
            var existingCard = GetCard(cardDeck, card.Id);
            if (existingCard != null)
            {
                existingCard.Value = card.Value;
                existingCard.Suit = card.Suit;
            }
        }
        public void DeleteCard(CardDeck cardDeck, int cardId)
        {
            var card = GetCard(cardDeck, cardId);
            if (card != null)
            {
                cardDeck.Cards.Remove(card);
                var deckCards = cardDeck.Cards.OrderBy(c => c.Order).ToList();
                for (int i = 0; i < deckCards.Count; i++)
                {
                    deckCards[i].Order = i + 1;
                }
            }
        }
    }
}
