using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoponline.api.Models
{
    public class Category
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
