using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;
using shoponline.Core.Services;

namespace shoponline.UnitTests.TestBuilders
{
    public class ProductServiceTestBuilder
    {
        private IProductRepository _productRepository;
        private bool _useDefaultProductRepository = true;

        public ProductServiceTestBuilder WithProductRepository(IProductRepository repository)
        {
            _useDefaultProductRepository = false;
            _productRepository = repository;
            return this;
        }

        public ProductService Build()
        {
            if (_useDefaultProductRepository)
            {
                _productRepository = GetDefaultProductRepository().Object;
            }
            return new ProductService(_productRepository);
        }
        private Mock<IProductRepository> GetDefaultProductRepository()
        { 
            var mock = new Mock<IProductRepository>();
            mock.Setup(x => x.GetByIdIncludingDependencies(It.IsAny<int>()))
                .Returns(new Product
                {
                    Id = 1
                });
            return mock;
        }
    }
}
