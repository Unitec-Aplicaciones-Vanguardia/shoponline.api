namespace shoponline.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public int BasketId { get; set; }

        public Basket Basket { get; set; }
    }
}
