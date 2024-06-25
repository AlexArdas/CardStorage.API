using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICardService
    {
        void AddCard(Card card);
        void UpdateCard(Card card);
        Card GetCard(int cardId, int cardDekId);
        void DeleteCard(int cardId, int cardDeckId);
        IEnumerable<Card> GetAllCardsInDeck(int cardDeckId);
    }
}
