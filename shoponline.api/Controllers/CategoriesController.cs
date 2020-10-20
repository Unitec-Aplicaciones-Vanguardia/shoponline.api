using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shoponline.api.Models;

namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Category[] _categories;
        private readonly Product[] _products;

        public CategoriesController()
        {
            var categories = System.IO.File.ReadAllText("Data/categories.json");
            _categories = JsonConvert.DeserializeObject<Category[]>(categories);

            var products = System.IO.File.ReadAllText("Data/products.json");
            _products = JsonConvert.DeserializeObject<Product[]>(products);
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categories;
        }

        [HttpGet]
        [Route("{categoryId}/products")]
        public IEnumerable<Product> Get(int categoryId)
        {
            var products = new List<Product>();
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].CategoryId == categoryId)
                {
                    products.Add(_products[i]);
                }
            }

            return products;
        }
    }
}
