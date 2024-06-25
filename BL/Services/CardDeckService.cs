using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace BL.Services
{
    public class CardDeckService : ICardDeckService
    {
        private readonly ICardDeckRepository _cardDeckRepository;

        public CardDeckService(ICardDeckRepository cardDeckRepository)
        {
            _cardDeckRepository = cardDeckRepository;
        }
        public void CreateCardDeck(CardDeck cardDeck)
        {
            _cardDeckRepository.CreateCardDeck(cardDeck);
        }

        public void UpdateCardDeck(CardDeck cardDeck)
        {
            _cardDeckRepository.UpdateCardDeck(cardDeck);
        }

        public CardDeck GetCardDeck(int cardDeckId)
        {
            return _cardDeckRepository.GetCardDeck(cardDeckId);
        }

        public IEnumerable<CardDeck> GetAllDecks()
        {
            return _cardDeckRepository.GetAllDecks();
        }

        public void DeleteCardDeck(int cardDeckId)
        {
            _cardDeckRepository.DeleteCardDeck(cardDeckId);
        }

        public void ShuffleCardDeck(int cardDeckId)
        {
            _cardDeckRepository.ShuffleCardDeck(cardDeckId);
        }
    }
}
