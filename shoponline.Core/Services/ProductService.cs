using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;

namespace shoponline.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public ServiceResult<IEnumerable<Product>> FilterByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return ServiceResult<IEnumerable<Product>>.SuccessResult(_productRepository.GetAll());
            }

            var products = _productRepository.Filter(p => p.Name.Contains(name));
            return products.Any()
                ? ServiceResult<IEnumerable<Product>>.SuccessResult(products)
                : ServiceResult<IEnumerable<Product>>.NotFoundResult(
                    $"No se encontraron productos con el nombre {name}");
        }

        public ServiceResult<Product> GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product != null
                ? ServiceResult<Product>.SuccessResult(product)
                : ServiceResult<Product>.NotFoundResult(
                    $"No se encontró el producto con el id {id}");
        }
    }
}
