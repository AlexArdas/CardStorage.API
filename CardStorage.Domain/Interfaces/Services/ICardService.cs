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
        /// <summary>
        /// Добавляет карту в указанную колоду.
        /// </summary>
        /// <param name="card">Запрос на добавление карты.</param>
        void AddCard(AddCardRequest card);
        /// <summary>
        /// Обновляет информацию о карте.
        /// </summary>
        /// <param name="card">Запрос на обновление карты.</param>
        void UpdateCard(UpdateCardRequest card);
        /// <summary>
        /// Получает информацию о карте по её идентификатору и идентификатору колоды.
        /// </summary>
        /// <param name="cardId">Идентификатор карты.</param>
        /// <param name="cardDekId">Идентификатор колоды, к которой относится карта.</param>
        /// <returns>Ответ с информацией о карте.</returns>
        GetCardResponse GetCard(int cardId, int cardDekId);
        /// <summary>
        /// Удаляет карту из указанной колоды.
        /// </summary>
        /// <param name="cardId">Идентификатор карты.</param>
        /// <param name="cardDeckId">Идентификатор колоды, из которой необходимо удалить карту.</param>
        void DeleteCard(int cardId, int cardDeckId);
        /// <summary>
        /// Получает все карты в указанной колоде.
        /// </summary>
        /// <param name="cardDeckId">Идентификатор колоды, для которой нужно получить все карты.</param>
        /// <returns>Ответ с коллекцией карт в указанной колоде.</returns>
        GetAllCardsInDeckResponse GetAllCardsInDeck(int cardDeckId);
    }
}
