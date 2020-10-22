using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using shoponline.api.Models;
using shoponline.Core.Entities;
using shoponline.Infrastructure;

namespace shoponline.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;

        public ProductsController(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        }
        //get, post, put, delete

        [HttpGet]
        public IEnumerable<Product> Get([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _shopOnlineDbContext.Products;
            }

            return _shopOnlineDbContext.Products.Where(p => p.Name.Contains(name));
        }

        [HttpGet]
        [Route("{productId}")]
        public Product Get(int productId)
        {
            return _shopOnlineDbContext.Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
