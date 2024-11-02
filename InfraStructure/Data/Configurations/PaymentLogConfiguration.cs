using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraStructure.Data.Configurations
{
    public class PaymentLogConfiguration : IEntityTypeConfiguration<PaymentLog>
    {
        public void Configure(EntityTypeBuilder<PaymentLog> builder)
        {
            builder
                .HasOne(pl => pl.Payment)
                .WithMany(p => p.PaymentLogs)
                .HasForeignKey(pl => pl.PaymentId);
        }
    }
}
