using CardStorage.Common.Request;
using CardStorage.Common.Response;
using CardStorage.Domain.Enum;
using Domain.Entities;
using Domain.Enum;
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
        public void CreateCardDeck(CreateCardDeckRequest cardDeckRequest)
        {
            var random = new Random();
            _cardDeckRepository.CreateCardDeck(new CardDeck
            {
                Id = random.Next(int.MaxValue),
                Name = cardDeckRequest.Name,
                Cards = cardDeckRequest.Cards.Select(c => new Card
                {
                    Id = random.Next(int.MaxValue),
                    CardDeckId = c.CardDeckId,
                    Order = c.Order,
                    Suit = (CardSuit) c.Suit,
                    Value = (CardValue) c.Value,
                }).ToList()
            });
        }

        public void UpdateCardDeck(UpdateCardDeckRequest cardDeckRequest)
        {
            _cardDeckRepository.UpdateCardDeck(new CardDeck
            {
                Id = cardDeckRequest.Id,
                Name = cardDeckRequest.Name,
            });
        }

        public GetCardDeckResponse GetCardDeck(int cardDeckId)
        {
            var cardDeck = _cardDeckRepository.GetCardDeck(cardDeckId);
            return new GetCardDeckResponse
            {
                Id = cardDeck.Id,
                Name = cardDeck.Name,
                Cards = cardDeck.Cards.Select(c => new GetCardResponse
                {
                    Id = c.Id,
                    CardDeckId = c.CardDeckId,
                    Order = c.Order,
                    Suit = c.Suit.ToString(),
                    Value = c.Value.ToString(),
                }).ToList()
            };
        }

        public GetAllDecksResponse GetAllDecks()
        {
            var cardDecks = _cardDeckRepository.GetAllDecks();
            return new GetAllDecksResponse
            {
                CardDecks = cardDecks.Select(c => new GetCardDeckResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Cards = c.Cards.Select(c => new GetCardResponse
                    {
                        Id = c.Id,
                        CardDeckId = c.CardDeckId,
                        Order = c.Order,
                        Suit = c.Suit.ToString(),
                        Value = c.Value.ToString(),
                    }).ToList()
                }).ToList()
            };
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
