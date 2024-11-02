using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraStructure.Data.Configurations
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder
                .HasOne(ci => ci.Product)
                .WithMany(p => p.BasketItems)
                .HasForeignKey(ci => ci.ProductId);
            builder
                .HasOne(ci => ci.Basket)
                .WithMany(c => c.BasketItems)
                .HasForeignKey(ci => ci.BasketId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
