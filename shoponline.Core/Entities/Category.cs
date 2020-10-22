using System.Collections.Generic;

namespace shoponline.Core.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
