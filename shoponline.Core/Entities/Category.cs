using System.Collections.Generic;

namespace shoponline.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
