using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using shoponline.api.Middlewares;
using shoponline.Core.Interfaces;
using shoponline.Core.Services;
using shoponline.Infrastructure;
using shoponline.Infrastructure.Repositories;

namespace shoponline.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);
            services.AddHttpContextAccessor();
            services.AddDbContext<ShopOnlineDbContext>((s, o) => o.UseSqlite("Data Source=data.db"));
            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseWhen(IsVerifyRequestNeeded, applicationBuilder => applicationBuilder.UseMiddleware<BuyerMiddleware>());

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private bool IsVerifyRequestNeeded(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/api/baskets");
        }
    }
}
