using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewAirlineBooking.Domain.Entities;

namespace NewAirlineBooking.Infrastructure.Persistence.Configurations;
public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable(nameof(Payment));
        builder.HasKey(p => p.Id);


        builder
            .HasOne(p => p.Booking)
            .WithOne(b => b.Payment)
            .HasForeignKey<Payment>(p => p.BookingId)
            .OnDelete(DeleteBehavior.Cascade);


        builder
            .Property(p => p.Amount)
            .HasColumnType("decimal")
            .IsRequired();

        builder
            .Property(p => p.PaymentDate)
            .HasColumnType<DateTime>("datetime")
            .IsRequired();

    }
}
