using CGICodeTest.Data;
using CGICodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGICodeTest.Services
{
    public class CardService : ICardService
    {
        ICardRepository _repo;

        public CardService(ICardRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        /// Adds a card
        /// </summary>
        /// <param name="card">The card object</param>
        public async Task AddAsync(BusinessCard card)
        {
            await _repo.AddAsync(card);
        }

        /// <summary>
        /// Deletes a card from the database
        /// </summary>
        /// <param name="id">The id of the object that will be deleted</param>
        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        /// <summary>
        /// Gets all cards from the database
        /// </summary>
        /// <returns>An IEnumerable of all cards</returns>
        public async Task<IEnumerable<BusinessCard>> GetAllAsync()
        {
            var allCards = await _repo.GetAllAsync();
            return allCards.ToList();
        }

        /// <summary>
        /// Gets a card from the database
        /// </summary>
        /// <param name="id">The cards Id value</param>
        /// <returns>A card object</returns>
        public async Task<BusinessCard> GetCardByIdAsync(int id)
        {
            return await _repo.GetCardByIdAsync(id);
        }

        /// <summary>
        /// Updates a card in the database
        /// </summary>
        /// <param name="card">The card object</param>
        public async Task UpdateAsync(BusinessCard card)
        {
            await _repo.UpdateAsync(card);
        }
    }
}
