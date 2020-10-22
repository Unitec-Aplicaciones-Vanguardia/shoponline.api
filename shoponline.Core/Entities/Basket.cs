using System.Collections.Generic;

namespace shoponline.Core.Entities
{
    public class Basket
    {
        public Basket()
        {
            Items = new List<BasketItem>();
        }
        public ICollection<BasketItem> Items { get; set; }

        public double Total { get; set; }

        public string BuyerId { get; set; }

        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
