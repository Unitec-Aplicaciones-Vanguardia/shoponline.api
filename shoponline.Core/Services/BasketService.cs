using System;
using System.Collections.Generic;
using System.Text;
using shoponline.Core.Entities;
using shoponline.Core.Enums;
using shoponline.Core.Interfaces;

namespace shoponline.Core.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBuyerService _buyerService;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Basket> _basebasketRepository;

        public BasketService(
            IBasketRepository basketRepository,
            IBuyerService buyerService,
            IRepository<Product> productRepository,
            IRepository<Basket> basebasketRepository)
        {
            _basketRepository = basketRepository;
            _buyerService = buyerService;
            _productRepository = productRepository;
            _basebasketRepository = basebasketRepository;
        }

        public ServiceResult<Basket> FindBasketByUserId(string userId)
        {
            var basket = _basketRepository.GetBasketForBuyer(userId);
            return basket == null
                ? ServiceResult<Basket>.NotFoundResult($"No se encontró basket para el usuario {userId}")
                : ServiceResult<Basket>.SuccessResult(basket);
        }

        public ServiceResult<Basket> AddBasketItem(int productId, int quantity)
        {
            var buyerIdServiceResult = _buyerService.GetBuyerId();

            if (buyerIdServiceResult.ResponseCode != ResponseCode.Success)
            {
                return ServiceResult<Basket>.ErrorResult(buyerIdServiceResult.Error);
            }

            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                return ServiceResult<Basket>.NotFoundResult($"El producto con id {productId} no existe");
            }

            var basketServiceResult = FindBasketByUserId(buyerIdServiceResult.Result);
            if (basketServiceResult.ResponseCode != ResponseCode.Success)
            {
                return CreateBasket(buyerIdServiceResult.Result, product, quantity);
            }

            AddBasketItem(basketServiceResult.Result, product, quantity);
            _basebasketRepository.SaveChanges();
            return ServiceResult<Basket>.SuccessResult(basketServiceResult.Result);
        }

        private void AddBasketItem(Basket basket, Product product, int quantity)
        {
            basket.Items.Add(new BasketItem
            {
                Price = product.Price,
                Quantity = quantity,
                Name = product.Name
            });

            basket.Total += product.Price * quantity;
        }

        private ServiceResult<Basket> CreateBasket(string buyerId, Product product, int quantity)
        {
            var newBasket = new Basket
            {
                BuyerId = buyerId,
                Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Price = product.Price,
                        Quantity = quantity,
                        Name = product.Name
                    }
                },
                Total = quantity * product.Price
            };
            var result = _basebasketRepository.Add(newBasket);
            return ServiceResult<Basket>.SuccessResult(result);
        }
    }
}
