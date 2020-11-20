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
        private readonly IBuyerService _buyerService;
        private readonly IBasketService _basketService;

        public BasketsController(IBuyerService buyerService, IBasketService basketService)
        {
            _buyerService = buyerService;
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

        [HttpPost]
        public ActionResult<Basket> Post([FromBody] AddBasketItem basketItem)
        {
            var serviceResult = _basketService.AddBasketItem(basketItem.ProductId, basketItem.Quantity);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);
            var result = new BasketDto
            {
                Id = serviceResult.Result.Id,
                BuyerId = serviceResult.Result.BuyerId,
                Total = serviceResult.Result.Total,
                Items = serviceResult.Result.Items.Select(x => new BasketItemDto
                {
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Id = x.Id,
                    Name = x.Name
                })
            };
            return Ok(result);
        }
    }
}
