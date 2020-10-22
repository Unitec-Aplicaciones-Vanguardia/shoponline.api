namespace shoponline.Core.Entities
{
    public class Product
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string BrandName { get; set; }

        public Brand Brand { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public int Id { get; set; }
    }
}
