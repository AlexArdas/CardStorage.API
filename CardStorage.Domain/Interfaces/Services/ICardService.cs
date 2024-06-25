using CardStorage.Common.Request;
using CardStorage.Common.Response;
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
        void AddCard(AddCardRequest card);
        void UpdateCard(UpdateCardRequest card);
        GetCardResponse GetCard(int cardId, int cardDekId);
        void DeleteCard(int cardId, int cardDeckId);
        GetAllCardsInDeckResponse GetAllCardsInDeck(int cardDeckId);
    }
}
