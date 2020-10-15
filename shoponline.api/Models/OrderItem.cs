using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoponline.api.Models
{
    public class OrderItem
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
