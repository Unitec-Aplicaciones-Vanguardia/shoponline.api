using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shoponline.api.Entities;
using shoponline.api.Models;

namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static readonly List<Basket> Baskets = new List<Basket>();
        private readonly Product[] _products;

        public BasketsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            var products = System.IO.File.ReadAllText("Data/products.json");
            _products = JsonConvert.DeserializeObject<Product[]>(products);
        }

        [HttpGet]
        public Basket Get()
        {
            var buyerId = _httpContextAccessor.HttpContext.Request.Headers["#BuyerId"];

            for (int i = 0; i < Baskets.Count; i++)
            {
                if (Baskets[i].BuyerId == buyerId)
                {
                    return Baskets[i];
                }
            }

            return null;
        }

        [HttpPost]
        public Basket Post([FromBody] AddBasketItem basketItem)
        {
            var buyerId = _httpContextAccessor.HttpContext.Request.Headers["#BuyerId"];

            var product = FindProduct(basketItem.ProductId);

            foreach (var basket in Baskets)
            {
                if (basket.BuyerId == buyerId)
                {
                    var items = basket.Items.ToList();
                    items.Add(new BasketItem
                    {
                        Price = product.Price,
                        Quantity = basketItem.Quantity,
                        Name = product.Name
                    });
                    basket.Items = items;
                    basket.Total += product.Price * basketItem.Quantity;
                    return basket;
                }
            }

            Baskets.Add(new Basket
            {
                BuyerId = buyerId,
                Items = new List<BasketItem>{ new BasketItem
                {
                    Price = product.Price,
                    Quantity = basketItem.Quantity,
                    Name = product.Name
                } },
                Total = basketItem.Quantity * product.Price
            });

            return Baskets.Last();
        }

        private Product FindProduct(int productId)
        {
            foreach (var product in _products)
            {
                if (product.Id == productId)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
