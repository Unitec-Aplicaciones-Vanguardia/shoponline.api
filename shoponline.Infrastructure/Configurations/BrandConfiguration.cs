using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shoponline.Core.Entities;

namespace shoponline.Infrastructure.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany<Product>(x => x.Products)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId);
        }
    }
}
