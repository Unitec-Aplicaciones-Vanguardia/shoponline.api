using Microsoft.EntityFrameworkCore;
using shoponline.Core.Entities;
using shoponline.Infrastructure.Configurations;

namespace shoponline.Infrastructure
{
    public class ShopOnlineDbContext : DbContext
    {
        public ShopOnlineDbContext(DbContextOptions options) :
            base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BasketConfiguration());
            modelBuilder.ApplyConfiguration(new BasketItemConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
