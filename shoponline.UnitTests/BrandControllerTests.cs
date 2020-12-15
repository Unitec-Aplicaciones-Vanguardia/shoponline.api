using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using shoponline.api.Models;
using shoponline.Core;
using shoponline.Core.Entities;
using shoponline.UnitTests.TestBuilders;
using Xunit;

namespace shoponline.UnitTests
{
    public class BrandControllerTests
    {
        [Theory]
        [InlineData("brand 1")]
        public void GetProducts_ExistingBrandName_Succeeds(string brandName)
        {
            //arrange
            var builder = new BrandControllerTestBuilder();
            var service = builder.GetDefaultBrandService();
            service.Setup(x => x.GetProductsByBrand(It.IsAny<string>()))
                .Returns(ServiceResult<IEnumerable<Product>>.SuccessResult(new List<Product>
                {
                    new Product
                    {
                        Name = "test",
                        Id = 1
                    }
                }));

            var controller = builder.WithBrandService(service.Object)
                .Build();

            //act
            var response = controller.Get(brandName);

            //assert
            Assert.IsType<ActionResult<IEnumerable<ProductDto>>>(response);
        }
    }
}
