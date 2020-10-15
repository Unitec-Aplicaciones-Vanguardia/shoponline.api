using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoponline.api.Models
{
    public class Basket
    {
        public IEnumerable<BasketItem> Items { get; set; }

        public decimal Total { get; set; }

        public string BuyerId { get; set; }
    }
}
