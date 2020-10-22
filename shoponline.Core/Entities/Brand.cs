using System.Collections.Generic;

namespace shoponline.Core.Entities
{
    public class Brand
    {
        public Brand()
        {
            Products = new List<Product>();
        }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
