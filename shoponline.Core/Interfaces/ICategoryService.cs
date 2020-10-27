using System;
using System.Collections.Generic;
using System.Text;
using shoponline.Core.Entities;

namespace shoponline.Core.Interfaces
{
    public interface ICategoryService
    {
        ServiceResult<IEnumerable<Category>> GetCategories();

        ServiceResult<IEnumerable<Product>> GetProductsByCategory(int categoryId);
    }
}
