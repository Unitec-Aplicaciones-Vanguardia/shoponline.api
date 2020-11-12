using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;

namespace shoponline.Infrastructure.Repositories
{
    public class BasketRepository : EntityFrameworkRepository<Basket>, IBasketRepository
    {
        public BasketRepository(ShopOnlineDbContext shopOnlineDbContext)
            : base(shopOnlineDbContext)
        {
        }

        public Basket GetBasketForBuyer(string buyerId)
        {
           return _shopOnlineDbContext.Baskets.FirstOrDefault(b => b.BuyerId == buyerId && !b.IsDeleted);
        }
    }
}
