using System;
using System.Collections.Generic;
using System.Text;
using shoponline.Core.Entities;

namespace shoponline.Core.Interfaces
{
    public interface IBasketRepository
    {
        Basket GetBasketForBuyer(string buyerId);
    }
}
