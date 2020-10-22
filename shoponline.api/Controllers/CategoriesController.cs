using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shoponline.api.Models;
using shoponline.Core.Entities;
using shoponline.Infrastructure;

namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;
        public CategoriesController(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _shopOnlineDbContext.Categories;
        }

        [HttpGet]
        [Route("{categoryId}/products")]
        public IEnumerable<Product> Get(int categoryId)
        {
            var products = _shopOnlineDbContext.Products.Where(p => p.CategoryId == categoryId);
            return products;
        }
    }
}
