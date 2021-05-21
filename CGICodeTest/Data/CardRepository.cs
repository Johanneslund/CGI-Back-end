using CGICodeTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGICodeTest.Data
{
    public class CardRepository : ICardRepository
    {

        private readonly CardContext _context;


        public CardRepository(CardContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a card to the database
        /// </summary>
        /// <param name="entity">The card to add</param>
        public async Task AddAsync(BusinessCard card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Deletes a card in the database
        /// </summary>
        /// <param name="id">The id of the item to be deleted</param>
        public async Task DeleteAsync(int id)
        {
            BusinessCard card = await GetCardByIdAsync(id);
             _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Gets all cards from the database
        /// </summary>
        /// <returns>An IEnumerable of the specified type</returns>
        public async Task<IEnumerable<BusinessCard>> GetAllAsync()
        {
            return await _context.Cards.ToListAsync();
        }


        /// <summary>
        /// Gets a specifik card from id
        /// </summary>
        /// <param name="id">The Id value to compare against the database</param>
        /// <returns>An object from the database</returns>
        public async Task<BusinessCard> GetCardByIdAsync(int id)
        {
            return await _context.Cards.FindAsync(id);
        }



        /// <summary>
        /// Updates a card in the database
        /// </summary>
        /// <param name="card">The card to update</param>
        public async Task UpdateAsync(BusinessCard card)
        {
            var oldCard = await GetCardByIdAsync(card.Id);

            oldCard.Name = card.Name;
            oldCard.SurName = card.SurName;
            oldCard.Image = card.Image;
            oldCard.Email = card.Email;
            oldCard.Telephone = card.Telephone;

            await _context.SaveChangesAsync();

        }


    }
}
