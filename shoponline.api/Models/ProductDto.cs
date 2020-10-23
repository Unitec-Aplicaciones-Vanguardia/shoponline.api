using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoponline.api.Models
{
    public class ProductDto
    {
        public double Price { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public int Id { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }
    }
}
