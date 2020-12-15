using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using shoponline.Core.Entities;
using shoponline.Core.Enums;
using shoponline.Core.Interfaces;
using shoponline.Core.Services;
using shoponline.UnitTests.Fakes;
using shoponline.UnitTests.TestBuilders;
using Xunit;

namespace shoponline.UnitTests
{
    public class ProductServiceTests
    {
        [Theory]
        [InlineData(1)]
        public void GetById_ExistingProductId_Success(int productId)
        {
            //arrange
            var builder = new ProductServiceTestBuilder();
            var service = builder.Build();

            //act
            var result = service.GetById(productId);

            //assert
            Assert.True(result.ResponseCode == ResponseCode.Success);
            Assert.NotNull(result.Result);
            Assert.Equal(productId, result.Result.Id);
        }

        [Theory]
        [InlineData(2)]
        public void GetById_NonExistingProductId_Success(int productId)
        {
            //arrange
            var builder = new ProductServiceTestBuilder();
            var service = builder.WithProductRepository(new FakeProductRepository()).Build();

            //act
            var result = service.GetById(productId);

            //assert
            Assert.True(result.ResponseCode == ResponseCode.NotFound);
            Assert.Null(result.Result);
        }
    }
}
