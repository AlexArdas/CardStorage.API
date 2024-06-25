using CardStorage.Common.Request;
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

        /// <summary>
        /// Получает колоду карт.
        /// </summary>
        [HttpGet("getCardDeck/{cardDeckId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCardDeck(int cardDeckId)
        {
            var deckCard = _cardDeckService.GetCardDeck(cardDeckId);
            return Ok(deckCard);
        }

        /// <summary>
        /// Получает список всех существующих колод карт.
        /// </summary>
        [HttpGet("allCardDecks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllDecks()
        {
            var cardDeck = _cardDeckService.GetAllDecks();
            return Ok(cardDeck);
        }

        /// <summary>
        /// Создает новую колоду карт.
        /// </summary>
        [HttpPost("createCardDeck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCardDeck([FromBody] CreateCardDeckRequest cardDeckRequest)
        {
            _cardDeckService.CreateCardDeck(cardDeckRequest);
            return Ok();
        }

        /// <summary>
        /// Обновляет информацию о существующей колоде карт.
        /// </summary>
        [HttpPut("updateCardDeck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCardDeck([FromBody] UpdateCardDeckRequest cardDeckRequest)
        {
            _cardDeckService.UpdateCardDeck(cardDeckRequest);
            return Ok();
        }

        /// <summary>
        /// Перемешивает карты в указанной колоде карт по идентификатору.
        /// </summary>
        [HttpPut("shuffleCardDeck/{cardDeckId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ShuffleCardDeck(int cardDeckId)
        {
            _cardDeckService.ShuffleCardDeck(cardDeckId);
            return Ok();
        }

        /// <summary>
        /// Удаляет колоду карт по идентификатору.
        /// </summary>
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
