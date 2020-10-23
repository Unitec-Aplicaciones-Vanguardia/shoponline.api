using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoponline.api.Models
{
    public class BasketDto
    {
        public IEnumerable<BasketItemDto> Items { get; set; }

        public double Total { get; set; }

        public string BuyerId { get; set; }

        public int Id { get; set; }
    }
}
