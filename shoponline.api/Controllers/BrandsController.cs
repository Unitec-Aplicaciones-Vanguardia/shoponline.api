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
    public class BrandsController : ControllerBase
    {
        private readonly Brand[] _brands;
        private readonly Product[] _products;

        public BrandsController()
        {
            var brands = System.IO.File.ReadAllText("Data/brands.json");
            _brands = JsonConvert.DeserializeObject<Brand[]>(brands);

            var products = System.IO.File.ReadAllText("Data/products.json");
            _products = JsonConvert.DeserializeObject<Product[]>(products);
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return _brands;
        }

        [HttpGet]
        [Route("{name}/products")]
        //brands/polo/products
        public IEnumerable<Product> Get(string name)
        {
            var products = new List<Product>();
            for (int i = 0; i < _products.Length; i++)
            {
                if (string.Equals(_products[i].BrandName, name, StringComparison.CurrentCultureIgnoreCase))
                {
                    products.Add(_products[i]);
                }
            }

            return products;
        }
    }
}
