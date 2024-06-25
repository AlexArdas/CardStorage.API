using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardStorage.API.Controllers
{
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("getCard/{cardId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCard(int cardId, int cardDeckId)
        {
            var card = _cardService.GetCard(cardId, cardDeckId);
            return Ok(card);
        }

        [HttpGet("getAllCardsInCardDeck/{cardDeckId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCardsInDeck(int cardDeckId)
        {
            var cards = _cardService.GetAllCardsInDeck(cardDeckId);
            return Ok(cards);
        }

        [HttpPost("addCardsToCardDeck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddCard([FromBody] IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                _cardService.AddCard(card);
            }
            return Ok();
        }

        [HttpPut("updateCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCard([FromBody] Card card)
        {
            _cardService.UpdateCard(card);
            return Ok();
        }

        [HttpDelete("deleteCard/{cardId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCard(int cardId, int cardDeckId)
        {
            _cardService.DeleteCard(cardId, cardDeckId);
            return Ok();
        }
    }
}
