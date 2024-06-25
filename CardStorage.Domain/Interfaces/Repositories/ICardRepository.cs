using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ICardRepository
    {
        /// <summary>
        /// Добавляет новую карту в указанную колоду карт.
        /// </summary>
        /// <param name="cardDeck">Колода карт, в которую добавляется карта.</param>
        /// <param name="card">Карта, которая добавляется.</param>
        void AddCard(CardDeck cardDeck, Card card);

        /// <summary>
        /// Обновляет информацию о карте в указанной колоде карт.
        /// </summary>
        /// <param name="cardDeck">Колода карт, в которой обновляется карта.</param>
        /// <param name="card">Карта с обновленными данными.</param>
        void UpdateCard(CardDeck cardDeck, Card card);

        /// <summary>
        /// Получает карту по её идентификатору из указанной колоды карт.
        /// </summary>
        /// <param name="cardDeck">Колода карт, из которой нужно получить карту.</param>
        /// <param name="cardId">Идентификатор карты.</param>
        /// <returns>Карта, если найдена, иначе null.</returns>
        Card GetCard(CardDeck cardDeck, int cardId);

        /// <summary>
        /// Удаляет карту по её идентификатору из указанной колоды карт.
        /// </summary>
        /// <param name="cardDeck">Колода карт, из которой нужно удалить карту.</param>
        /// <param name="cardId">Идентификатор карты, которую нужно удалить.</param>
        void DeleteCard(CardDeck cardDeck, int cardId);

        /// <summary>
        /// Получает все карты в указанной колоде карт.
        /// </summary>
        /// <param name="cardDeck">Колода карт, для которой нужно получить все карты.</param>
        /// <returns>Перечисление карт в колоде.</returns>
        IEnumerable<Card> GetAllCardsInDeck(CardDeck cardDeck);
    }
}
