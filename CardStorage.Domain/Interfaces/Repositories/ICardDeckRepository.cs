using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ICardDeckRepository
    {
        /// <summary>
        /// Создает новую колоду карт.
        /// </summary>
        /// <param name="cardDeck">Данные для создания новой колоды карт.</param>
        void CreateCardDeck(CardDeck cardDeck);

        /// <summary>
        /// Обновляет информацию о существующей колоде карт.
        /// </summary>
        /// <param name="cardDeck">Колода карт с обновленными данными.</param>
        void UpdateCardDeck(CardDeck cardDeck);

        /// <summary>
        /// Получает колоду карт по её идентификатору.
        /// </summary>
        /// <param name="cardDeckId">Идентификатор колоды карт.</param>
        /// <returns>Колода карт, если найдена, иначе null.</returns>
        CardDeck GetCardDeck(int cardDeckId);

        /// <summary>
        /// Удаляет колоду карт по её идентификатору.
        /// </summary>
        /// <param name="cardDeckId">Идентификатор колоды карт, которую нужно удалить.</param>
        void DeleteCardDeck(int cardDeckId);

        /// <summary>
        /// Получает все существующие колоды карт.
        /// </summary>
        /// <returns>Перечисление всех колод карт.</returns>
        IEnumerable<CardDeck> GetAllDecks();

        /// <summary>
        /// Перемешивает карты в указанной колоде карт.
        /// </summary>
        /// <param name="cardDeckId">Идентификатор колоды карт, которую нужно перемешать.</param>
        void ShuffleCardDeck(int cardDeckId);
    }
}
