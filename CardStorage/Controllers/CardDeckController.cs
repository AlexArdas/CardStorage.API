using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardStorage.API.Controllers
{
    [ApiController]
    public class CardDeckController : ControllerBase
    {
        private readonly ICardDeckService _cardDeckService;

        public CardDeckController(ICardDeckService cardDeckService)
        {
            _cardDeckService = cardDeckService;
        }

        [HttpGet("getCardDeck/{cardId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCardDeck(int cardId)
        {
            var deckCard = _cardDeckService.GetCardDeck(cardId);
            return Ok(deckCard);
        }

        [HttpGet("allDecks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllDecks()
        {
            var cardDeck = _cardDeckService.GetAllDecks();
            return Ok(cardDeck);
        }

        [HttpPost("createCardDeck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCardDeck([FromBody] CardDeck cardDeck)
        {
            _cardDeckService.CreateCardDeck(cardDeck);
            return Ok();
        }

        [HttpPut("updateCardDeck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCardDeck([FromBody] CardDeck cardDeck)
        {
            _cardDeckService.UpdateCardDeck(cardDeck);
            return Ok();
        }

        [HttpPut("shuffleCardDeck/{cardDeckId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ShuffleCardDeck(int cardDeckId)
        {
            _cardDeckService.ShuffleCardDeck(cardDeckId);
            return Ok();
        }

        [HttpDelete("deleteCardDeck/{cardDeckId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCardDeck(int cardDeckId)
        {
            _cardDeckService.DeleteCardDeck(cardDeckId);
            return Ok();
        }
    }
}
