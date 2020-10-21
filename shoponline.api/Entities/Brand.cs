using System.Collections.Generic;
using shoponline.api.Models;

namespace shoponline.api.Entities
{
    public class Brand
    {
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
