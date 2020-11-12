using System;
using System.Collections.Generic;
using System.Text;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;

namespace shoponline.Core.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public ServiceResult<Basket> FindBasketByUserId(string userId)
        {
            var basket = _basketRepository.GetBasketForBuyer(userId);
            return basket == null
                ? ServiceResult<Basket>.NotFoundResult($"No se encontró basket para el usuario {userId}")
                : ServiceResult<Basket>.SuccessResult(basket);
        }
    }
}
