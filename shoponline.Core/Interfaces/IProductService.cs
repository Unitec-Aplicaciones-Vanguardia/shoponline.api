using System;
using System.Collections.Generic;
using System.Text;
using shoponline.Core.Entities;

namespace shoponline.Core.Interfaces
{
    public interface IProductService
    {
        ServiceResult<IEnumerable<Product>> FilterByName(string name);

        ServiceResult<Product> GetById(int id);
    }
}
