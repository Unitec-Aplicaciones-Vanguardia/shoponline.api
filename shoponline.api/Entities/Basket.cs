using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoponline.api.Entities
{
    public class Basket
    {
        public IEnumerable<BasketItem> Items { get; set; }

        public double Total { get; set; }

        public string BuyerId { get; set; }

        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
