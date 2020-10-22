using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shoponline.Core.Entities;

namespace shoponline.Infrastructure.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Name);

            builder.HasMany<Product>(x => x.Products)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandName);
        }
    }
}
