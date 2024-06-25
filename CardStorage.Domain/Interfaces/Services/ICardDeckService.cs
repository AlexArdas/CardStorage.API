using CardStorage.Common.Request;
using CardStorage.Common.Response;

namespace Domain.Interfaces.Services
{
    public interface ICardDeckService
    {
        void CreateCardDeck(CreateCardDeckRequest cardDeckRequest);
        void UpdateCardDeck(UpdateCardDeckRequest cardDeckRequest);
        GetCardDeckResponse GetCardDeck(int id);
        GetAllDecksResponse GetAllDecks();
        void DeleteCardDeck(int id);
        void ShuffleCardDeck(int id);
    }
}
