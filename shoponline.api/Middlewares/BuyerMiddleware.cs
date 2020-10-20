using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace shoponline.api.Middlewares
{
    public class BuyerMiddleware
    {
        private readonly RequestDelegate _next;

        public BuyerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isValidRequest = context.Request.Headers.ContainsKey("#BuyerId");
            if (isValidRequest)
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Invalid Request");
            }
        }
    }
}
