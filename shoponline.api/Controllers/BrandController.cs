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
    public class BrandController : ControllerBase
    {
        private static readonly Brand[] Brands = new[]
        {
            new Brand
            {
                Name = "Microsoft",
                Categories = new List<Category>
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
                    }
                }
            },
            new Brand
            {
                Name = "Sony",
                Categories = new List<Category>
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
                            }
                        }
                    }
                }
            },
            new Brand
            {
                Name = "Apple",
                Categories = new List<Category>
                {
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
                }
            }
        };

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return Brands;
        }

        [HttpGet]
        [Route("{name}")]
        public IEnumerable<Category> Get(string name)
        {
            for (int i = 0; i < Brands.Length; i++)
            {
                if (Brands[i].Name == name)
                {
                    return Brands[i].Categories;
                }
            }

            return null;
        }
    }
}
