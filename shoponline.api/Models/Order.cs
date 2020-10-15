using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoponline.api.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTimeOffset OrderDate { get; } = DateTimeOffset.Now;

        public Address ShipToAddress { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Total { get; set; }

        public string BuyerName { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}
