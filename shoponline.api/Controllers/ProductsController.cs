using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using shoponline.api.Models;
using shoponline.Core.Entities;
using shoponline.Core.Enums;
using shoponline.Core.Interfaces;
using shoponline.Infrastructure;

namespace shoponline.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<ProductDto> Get([FromQuery] string name)
        {
            var serviceResult = _productService.FilterByName(name);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var products = serviceResult.Result;
            return Ok(products.Select(p => new ProductDto
            {
                Id = p.Id,
                BrandName = p.Brand.Name,
                Name = p.Name,
                Stock = p.Stock,
                CategoryName = p.Category.Description,
                Price = p.Price
            }));
        }

        [HttpGet]
        [Route("{productId}")]
        public ActionResult<Product> Get(int productId)
        {
            var serviceResult = _productService.GetById(productId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var product = serviceResult.Result;

            return Ok(new ProductDto
            {
                Id = product.Id,
                BrandName = product.Brand.Name,
                Name = product.Name,
                Stock = product.Stock,
                CategoryName = product.Category.Description,
                Price = product.Price
            });
        }
    }
}
