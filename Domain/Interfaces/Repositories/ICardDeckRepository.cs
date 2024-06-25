using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ICardDeckRepository
    {
        void CreateCardDeck(CardDeck cardDeck);
        void UpdateCardDeck(CardDeck cardDeck);
        CardDeck GetCardDeck(int cardDeckId);
        void DeleteCardDeck(int cardDeckId);
        IEnumerable<CardDeck> GetAllDecks();
        void ShuffleCardDeck(int cardDeckId);
    }
}
