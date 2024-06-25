using CardStorage.Common.Request;
using CardStorage.Common.Response;

namespace Domain.Interfaces.Services
{
    public interface ICardDeckService
    {
        /// <summary>
        /// Создает новую колоду карт.
        /// </summary>
        /// <param name="cardDeckRequest">Запрос на создание колоды карт.</param>
        void CreateCardDeck(CreateCardDeckRequest cardDeckRequest);

        /// <summary>
        /// Обновляет информацию о существующей колоде карт.
        /// </summary>
        /// <param name="cardDeckRequest">Запрос на обновление колоды карт.</param>
        void UpdateCardDeck(UpdateCardDeckRequest cardDeckRequest);

        /// <summary>
        /// Получает информацию о колоде карт по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор колоды карт.</param>
        /// <returns>Ответ с информацией о колоде карт.</returns>
        GetCardDeckResponse GetCardDeck(int id);

        /// <summary>
        /// Получает все существующие колоды карт.
        /// </summary>
        /// <returns>Ответ со списком всех колод карт.</returns>
        GetAllDecksResponse GetAllDecks();

        /// <summary>
        /// Удаляет колоду карт по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор колоды карт, которую нужно удалить.</param>
        void DeleteCardDeck(int id);

        /// <summary>
        /// Перемешивает карты в указанной колоде по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор колоды карт, которую нужно перемешать.</param>
        void ShuffleCardDeck(int id);
    }
}
