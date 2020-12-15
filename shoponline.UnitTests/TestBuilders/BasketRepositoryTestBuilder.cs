using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using shoponline.Core.Entities;
using shoponline.Infrastructure;
using shoponline.Infrastructure.Repositories;

namespace shoponline.UnitTests.TestBuilders
{
    public class BasketRepositoryTestBuilder
    {
        private ShopOnlineDbContext _context;
        private Mock<ShopOnlineDbContext> _contextMock;
        private bool _useDefaultContext = true;

        public BasketRepositoryTestBuilder WithInMemoryContext(ShopOnlineDbContext context)
        {
            _useDefaultContext = false;
            _context = context;
            return this;
        }

        public BasketRepositoryTestBuilder WithBaskets(IEnumerable<Basket> baskets)
        {
            _contextMock ??= new Mock<ShopOnlineDbContext>();
            var basketsMock = new Mock<DbSet<Basket>>();
            basketsMock.As<IQueryable<Basket>>().Setup(b => b.Provider).Returns(baskets.AsQueryable().Provider);
            basketsMock.As<IQueryable<Basket>>().Setup(b => b.Expression).Returns(baskets.AsQueryable().Expression);
            basketsMock.As<IQueryable<Basket>>().Setup(b => b.ElementType).Returns(baskets.AsQueryable().ElementType);
            basketsMock.As<IQueryable<Basket>>().Setup(b => b.GetEnumerator()).Returns(baskets.AsQueryable().GetEnumerator);
            _contextMock.Setup(c => c.Set<Basket>())
                .Returns(basketsMock.Object);
            return this;
        }

        public BasketRepository Build()
        {
            if (_useDefaultContext)
            {
                _context = _contextMock.Object;
            }

            return new BasketRepository(_context);
        }
    }
}
