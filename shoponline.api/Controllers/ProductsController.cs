using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using shoponline.api.Entities;
using shoponline.api.Models;

namespace shoponline.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly Product[] _products;

        public ProductsController()
        {
            var products = System.IO.File.ReadAllText("Data/products.json");
            _products = JsonConvert.DeserializeObject<Product[]>(products);
        }
        //get, post, put, delete

        [HttpGet]
        public IEnumerable<Product> Get([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _products;
            }

            var products = new List<Product>();
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].Name.ToLower().Contains(name.ToLower()))
                {
                    products.Add(_products[i]);
                }
            }

            return products;
        }

        [HttpGet]
        [Route("{productId}")]
        public Product Get(int productId)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].Id == productId)
                {
                    return _products[i];
                }
            }

            return null;
        }
    }
}
