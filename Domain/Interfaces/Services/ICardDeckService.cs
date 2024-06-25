using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICardDeckService
    {
        void CreateCardDeck(CardDeck cardDeck);
        void UpdateCardDeck(CardDeck cardDeck);
        CardDeck GetCardDeck(int id);
        IEnumerable<CardDeck> GetAllDecks();
        void DeleteCardDeck(int id);
        void ShuffleCardDeck(int id);
    }
}
