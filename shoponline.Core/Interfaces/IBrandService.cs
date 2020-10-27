using System;
using System.Collections.Generic;
using System.Text;
using shoponline.Core.Entities;

namespace shoponline.Core.Interfaces
{
    public interface IBrandService
    {
        ServiceResult<IEnumerable<Brand>> GetBrands();

        ServiceResult<IEnumerable<Product>> GetProductsByBrand(string name);
    }
}
