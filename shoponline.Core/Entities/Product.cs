﻿namespace shoponline.Core.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }
    }
}
