using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using shoponline.api.Controllers;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;

namespace shoponline.UnitTests.TestBuilders
{
    public class BrandControllerTestBuilder
    {
        private IBrandService _brandService;
        private bool _useDefaultBrandService = true;

        public BrandControllerTestBuilder WithBrandService(IBrandService brandService)
        {
            _useDefaultBrandService = false;
            _brandService = brandService;
            return this;
        }

        public BrandsController Build()
        {
            if (_useDefaultBrandService)
            {
                _brandService = GetDefaultBrandService().Object;
            }
            return new BrandsController(_brandService);
        }
        public Mock<IBrandService> GetDefaultBrandService() => new Mock<IBrandService>();
    }
}
