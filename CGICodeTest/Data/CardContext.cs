using CGICodeTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGICodeTest.Data
{
    public class CardContext : DbContext
    {

        public CardContext(DbContextOptions<CardContext> options) : base(options)
        {

        }

        public DbSet<BusinessCard> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cards = new List<BusinessCard>
            {
                new BusinessCard { Id = 1, Name = "Johannes", SurName = "Lundkvist", Email="Janne@live.se", Telephone = "12312312" }
            };

            modelBuilder.Entity<BusinessCard>().HasData(cards);


        }


    }
}
