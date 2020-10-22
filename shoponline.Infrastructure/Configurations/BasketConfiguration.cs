using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shoponline.Core.Entities;

namespace shoponline.Infrastructure.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.BuyerId).IsRequired();

            builder.HasMany(x => x.Items)
                .WithOne(i => i.Basket)
                .HasForeignKey(x => x.BasketId);
        }
    }
}
