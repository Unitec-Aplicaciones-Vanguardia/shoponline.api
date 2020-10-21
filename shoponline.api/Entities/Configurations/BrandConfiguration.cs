using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace shoponline.api.Entities.Configurations
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
