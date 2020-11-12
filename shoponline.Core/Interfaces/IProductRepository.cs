using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using shoponline.Core.Entities;

namespace shoponline.Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> FilterIncludingDependencies(Expression<Func<Product, bool>> predicate);
    }
}
