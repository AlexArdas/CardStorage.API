using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ICardRepository
    {
        void AddCard(CardDeck cardDeck, Card card);
        void UpdateCard(CardDeck cardDeck, Card card);
        Card GetCard(CardDeck cardDeck, int cardId);
        void DeleteCard(CardDeck cardDeck, int cardId);
        IEnumerable<Card> GetAllCardsInDeck(CardDeck cardDeck);
    }
}
