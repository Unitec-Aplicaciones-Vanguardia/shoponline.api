using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;

namespace shoponline.UnitTests.Fakes
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly IEnumerable<Product> _products;

        public FakeProductRepository()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Name = "fake product",
                    Id = 1
                }
            };
        }
        public IEnumerable<Product> GetAllIncludingDependencies()
        {
            throw new NotImplementedException();
        }

        public Product GetByIdIncludingDependencies(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> FilterIncludingDependencies(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
