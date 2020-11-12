using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;

namespace shoponline.Infrastructure.Repositories
{
    public class ProductRepository: EntityFrameworkRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
            : base(shopOnlineDbContext)
        {
        }

        public IEnumerable<Product> FilterIncludingDependencies(Expression<Func<Product, bool>> predicate)
        {
            return _shopOnlineDbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Where(predicate).ToList();
        }
    }
}
