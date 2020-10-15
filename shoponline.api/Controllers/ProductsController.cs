using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shoponline.api.Models;

namespace shoponline.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly Product[] Products = new[]
        {
            new Product
            {
                Brand = new Brand
                {
                    Name = "Sony"
                },
                Name = "Play Station 5",
                Id = 1,
                Category = new Category
                {
                    Id = 1,
                    Description = "Consoles"
                },
                Price = 399,
                Stock = 1
            },
            new Product
            {
                Brand = new Brand
                {
                    Name = "Microsoft"
                },
                Name = "Xbox",
                Id = 2,
                Category = new Category
                {
                    Id = 1,
                    Description = "Consoles"
                },
                Price = 499,
                Stock = 2
            },
            new Product
            {
                Brand = new Brand
                {
                    Name = "Apple"
                },
                Name = "iPhone 12",
                Id = 3,
                Category = new Category
                {
                    Id = 2,
                    Description = "Cellphones"
                },
                Price = 1200,
                Stock = 5
            }
        };

        //get, post, put, delete

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        [HttpGet]
        [Route("{productId}")]
        public Product Get(int productId)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Id == productId)
                {
                    return Products[i];
                }
            }

            return null;
        }

        [HttpGet]
        [Route("filter/{name}")]
        public Product Get(string name)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Name == name)
                {
                    return Products[i];
                }
            }

            return null;
        }
    }
}
