using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;

namespace shoponline.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;

        public CategoryService(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public ServiceResult<IEnumerable<Category>> GetCategories()
        {
            return ServiceResult<IEnumerable<Category>>.SuccessResult(_categoryRepository.GetAll());
        }

        public ServiceResult<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            var products = _productRepository.Filter(p => p.CategoryId == categoryId);
            return products.Any()
                ? ServiceResult<IEnumerable<Product>>.SuccessResult(products)
                : ServiceResult<IEnumerable<Product>>.NotFoundResult(
                    $"No se encontraron productos para la categoría {categoryId}");
        }
    }
}
