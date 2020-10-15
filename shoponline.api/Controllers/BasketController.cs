using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoponline.api.Models;

namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private static readonly List<Basket> Baskets = new List<Basket>
        {
            new Basket
            {
                BuyerId = "carlos.varela@unitec.edu",
                Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Name = "Xbox",
                        Price = 499,
                        Quantity = 1
                    },
                    new BasketItem
                    {
                        Name = "iPhone",
                        Price = 1200,
                        Quantity = 2
                    }
                }
            },
            new Basket
            {
                BuyerId = "juan.perez@unitec.edu",
                Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Name = "Play Station 5",
                        Price = 399,
                        Quantity = 1
                    }
                }
            }
        };

        [HttpGet]
        [Route("{buyerId}")]
        public Basket Get(string buyerId)
        {
            for (int i = 0; i < Baskets.Count; i++)
            {
                if (Baskets[i].BuyerId == buyerId)
                {
                    foreach (var basketItem in Baskets[i].Items)
                    {
                        Baskets[i].Total += basketItem.Price * basketItem.Quantity;
                    }
                    return Baskets[i];
                }
            }

            return null;
        }

        [HttpPost]
        [Route("{buyerId}")]
        public Basket Post([FromBody] BasketItem basketItem, string buyerId)
        {
            foreach (var basket in Baskets)
            {
                if (basket.BuyerId == buyerId)
                {
                    var items = basket.Items.ToList();
                    items.Add(basketItem);
                    basket.Items = items;
                    basket.Total += basketItem.Price * basketItem.Quantity;
                    return basket;
                }
            }

            Baskets.Add(new Basket
            {
                BuyerId = buyerId,
                Items = new List<BasketItem>{ basketItem },
                Total = basketItem.Quantity * basketItem.Price
            });

            return Baskets.Last();
        }
    }
}
