using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using shoponline.Core.Entities;

namespace shoponline.Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllIncludingDependencies();

        Product GetByIdIncludingDependencies(int id);

        IEnumerable<Product> FilterIncludingDependencies(Expression<Func<Product, bool>> predicate);
    }
}
