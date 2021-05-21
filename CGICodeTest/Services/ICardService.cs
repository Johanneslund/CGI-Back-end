using CGICodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGICodeTest.Services
{
    public interface ICardService
    {
        Task DeleteAsync(int id);

        Task AddAsync(BusinessCard Card);

        Task UpdateAsync(BusinessCard Card);

        Task<IEnumerable<BusinessCard>> GetAllAsync();

        Task<BusinessCard> GetCardByIdAsync(int id);


    }
}
