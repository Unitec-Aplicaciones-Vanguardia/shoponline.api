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
using shoponline.Infrastructure;

namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;

        public BrandsController(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BrandDto>> Get()
        {
            return Ok(_shopOnlineDbContext.Brands.Select(b => new BrandDto
            {
                Name = b.Name
            }));
        }

        [HttpGet]
        [Route("{name}/products")]
        public ActionResult<IEnumerable<ProductDto>> Get(string name)
        {
            var products = _shopOnlineDbContext.Products.Where(p => p.BrandName == name);
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
