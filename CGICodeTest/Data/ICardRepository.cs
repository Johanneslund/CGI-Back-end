using CGICodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGICodeTest.Data
{
    public interface ICardRepository
    {

        Task<IEnumerable<BusinessCard>> GetAllAsync();

        Task<BusinessCard> GetCardByIdAsync(int id);

        Task AddAsync(BusinessCard card);

        Task UpdateAsync(BusinessCard card);

        Task DeleteAsync(int id);


    }
}
