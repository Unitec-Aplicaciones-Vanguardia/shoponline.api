using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoponline.api.Models
{
    public class AddBasketItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
