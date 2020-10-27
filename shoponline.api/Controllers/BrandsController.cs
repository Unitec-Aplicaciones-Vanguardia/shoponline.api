using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using shoponline.api.Models;
using shoponline.Core.Entities;
using shoponline.Core.Enums;
using shoponline.Core.Interfaces;
using shoponline.Infrastructure;

namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BrandDto>> Get()
        {
            var serviceResult = _brandService.GetBrands();
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            return Ok(serviceResult.Result.Select(b => new BrandDto
            {
                Name = b.Name
            }));
        }

        [HttpGet]
        [Route("{name}/products")]
        public ActionResult<IEnumerable<ProductDto>> Get(string name)
        {
            var serviceResult = _brandService.GetProductsByBrand(name);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var products = serviceResult.Result;
            return Ok(products.Select(p => new ProductDto
            {
                Id = p.Id,
                BrandName = p.BrandName,
                Name = p.Name,
                Stock = p.Stock,
                CategoryName = p.Category.Description,
                Price = p.Price
            }));
        }
    }
}
