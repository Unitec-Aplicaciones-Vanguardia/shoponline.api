using System;
using System.Collections.Generic;
using System.Text;
using shoponline.Core.Entities;
using shoponline.UnitTests.TestBuilders;
using Xunit;

namespace shoponline.UnitTests
{
    public class BasketRepositoryTests
    {
        [Theory]
        [InlineData("carlos.varela@unitec.edu")]
        public void GetBasketForBuyer_ExistingBuyer_Succeeds(string buyerId)
        {
            //arrange
            var builder = new BasketRepositoryTestBuilder();
            var context = DbContextUtils.GetInMemoryContext();
            context.SeedBaskets();
            var repository = builder.WithInMemoryContext(context)
                .Build();

            //act
            var basket = repository.GetBasketForBuyer(buyerId);

            //assert
            Assert.NotNull(basket);
            Assert.Equal(buyerId, basket.BuyerId);
            Assert.False(basket.IsDeleted);
        }

        [Theory]
        [InlineData("carlos.varela@unitec.edu")]
        public void GetBasketForBuyer_ExistingBuyer_Succeeds2(string buyerId)
        {
            //arrange
            var builder = new BasketRepositoryTestBuilder();
            var baskets = new List<Basket>
            {
                new Basket
                {
                    BuyerId = "carlos.varela@unitec.edu",
                    Id = 1,
                    IsDeleted = false
                }
            };
            var repository = builder.WithBaskets(baskets)
                .Build();

            //act
            var basket = repository.GetBasketForBuyer(buyerId);

            //assert
            Assert.NotNull(basket);
            Assert.Equal(buyerId, basket.BuyerId);
            Assert.False(basket.IsDeleted);
        }
    }
}
