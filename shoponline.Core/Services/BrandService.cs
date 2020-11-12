using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;

namespace shoponline.Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly IProductRepository _productRepository;

        public BrandService(IRepository<Brand> brandRepository, IProductRepository productRepository)
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository;
        }

        public ServiceResult<IEnumerable<Brand>> GetBrands()
        {
            return ServiceResult<IEnumerable<Brand>>.SuccessResult(_brandRepository.GetAll());
        }

        public ServiceResult<IEnumerable<Product>> GetProductsByBrand(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return ServiceResult<IEnumerable<Product>>.ErrorResult("El nombre de la marca no puede ser nulo");
            }

            var result = _productRepository.FilterIncludingDependencies( b => b.Brand.Name == name);

            return !result.Any()
                ? ServiceResult<IEnumerable<Product>>.NotFoundResult(
                    $"No se encontraron productos para la marca {name}")
                : ServiceResult<IEnumerable<Product>>.SuccessResult(result);
        }
    }
}
