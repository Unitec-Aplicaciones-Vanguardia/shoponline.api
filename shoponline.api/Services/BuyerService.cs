using System;
using Microsoft.AspNetCore.Http;
using shoponline.Core;
using shoponline.Core.Interfaces;

namespace shoponline.api.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string _buyerIdHeader = "#BuyerId";

        public BuyerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ServiceResult<string> GetBuyerId()
        {
            return ServiceResult<string>.SuccessResult(_httpContextAccessor.HttpContext.Request.Headers["#BuyerId"].ToString());
        }
    }
}
