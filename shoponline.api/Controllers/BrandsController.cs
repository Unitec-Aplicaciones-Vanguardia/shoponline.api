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
        public IEnumerable<Brand> Get()
        {
            return _shopOnlineDbContext.Brands;
        }

        [HttpGet]
        [Route("{name}/products")]
        public IEnumerable<Product> Get(string name)
        {
            var products = _shopOnlineDbContext.Products.Where(p => p.BrandName == name);
            return products;
        }
    }
}
