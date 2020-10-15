using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoponline.api.Models;

namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static readonly Category[] Categories = new[]
        {
            new Category
            {
                Id = 1,
                Description = "Consoles",
                Products = new List<Product>
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
                    }
                }
            },
            new Category
            {
                Id = 2,
                Description = "Cellphones",
                Products = new List<Product>
                {
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
                }
            }
        };

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return Categories;
        }

        [HttpGet]
        [Route("{categoryId}")]
        public IEnumerable<Product> Get(int categoryId)
        {
            for (int i = 0; i < Categories.Length; i++)
            {
                if (Categories[i].Id == categoryId)
                {
                    return Categories[i].Products;
                }
            }

            return null;
        }
    }
}
