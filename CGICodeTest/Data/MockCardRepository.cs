using CGICodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGICodeTest.Data
{
    public class MockCardRepository : ICardRepository
    {


        public Task AddAsync(BusinessCard card)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BusinessCard>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BusinessCard> GetCardByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BusinessCard card)
        {
            throw new NotImplementedException();
        }
    }
}
