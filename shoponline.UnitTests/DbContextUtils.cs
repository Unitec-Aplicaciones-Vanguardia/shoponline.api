using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using shoponline.Core.Entities;
using shoponline.Infrastructure;

namespace shoponline.UnitTests
{
    public static class DbContextUtils
    {
        public static ShopOnlineDbContext GetInMemoryContext()
        {
            var connection = new SqliteConnection("DataSource=:memory:");

            connection.Open();

            var dbContextOptions = new DbContextOptionsBuilder<ShopOnlineDbContext>()
                .UseSqlite(connection)
                .Options;

            var context = new ShopOnlineDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            return context;
        }

        public static void SeedBaskets(this ShopOnlineDbContext context)
        {
            var baskets = new List<Basket>
            {
                new Basket
                {
                    BuyerId = "carlos.varela@unitec.edu",
                    Id = 1,
                    IsDeleted = false
                }
            };
            context.AddRange(baskets);
            context.SaveChanges();
        }
    }
}
