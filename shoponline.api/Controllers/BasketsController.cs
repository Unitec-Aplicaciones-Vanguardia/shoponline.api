using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shoponline.api.Models;
using shoponline.Core.Entities;
using shoponline.Core.Enums;
using shoponline.Core.Interfaces;
using shoponline.Infrastructure;

namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBasketService _basketService;

        public BasketsController(IHttpContextAccessor httpContextAccessor, IBasketService basketService)
        {
            _httpContextAccessor = httpContextAccessor;
            _basketService = basketService;
        }

        //[HttpGet]
        //public ActionResult<BasketDto> Get()
        //{
        //    var buyerId = _httpContextAccessor.HttpContext.Request.Headers["#BuyerId"].ToString();
        //    var serviceResult = _basketService.FindBasketByUserId(buyerId);
        //    if (serviceResult.ResponseCode == ResponseCode.NotFound)
        //        return NotFound(serviceResult.Error);

        //    var basket = serviceResult.Result;

        //    return Ok(new BasketDto
        //    {
        //        Id = basket.Id,
        //        BuyerId = basket.BuyerId,
        //        Total = basket.Total,
        //        Items = basket.Items.Select(i => new BasketItemDto
        //        {
        //            Price = i.Price,
        //            Quantity = i.Quantity,
        //            Id = i.Id,
        //            Name = i.Name
        //        })
        //    });
        //}

        //[HttpPost]
        //public Basket Post([FromBody] AddBasketItem basketItem)
        //{
        //    var buyerId = _httpContextAccessor.HttpContext.Request.Headers["#BuyerId"].ToString();

        //    var product = _shopOnlineDbContext.Products.FirstOrDefault(p => p.Id == basketItem.ProductId);
        //    if (product == null)
        //    {
        //        return null;
        //    }

        //    var basket = _shopOnlineDbContext.Baskets.FirstOrDefault(b => b.BuyerId == buyerId && !b.IsDeleted);

        //    if (basket != null)
        //    {
        //        basket.Items.Add(new BasketItem
        //        {
        //            Price = product.Price,
        //            Quantity = basketItem.Quantity,
        //            Name = product.Name
        //        });
        //        basket.Total += product.Price * basketItem.Quantity;
        //        _shopOnlineDbContext.SaveChanges();
        //        return basket;
        //    }

        //    var newBasket = new Basket
        //    {
        //        BuyerId = buyerId,
        //        Items = new List<BasketItem>
        //        {
        //            new BasketItem
        //            {
        //                Price = product.Price,
        //                Quantity = basketItem.Quantity,
        //                Name = product.Name
        //            }
        //        },
        //        Total = basketItem.Quantity * product.Price
        //    };
        //    _shopOnlineDbContext.Baskets.Add(newBasket);
        //    _shopOnlineDbContext.SaveChanges();
        //    return newBasket;
        //}
    }
}
