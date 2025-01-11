using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewAirlineBooking.Domain.Entities;

namespace NewAirlineBooking.Infrastructure.Persistence.Configurations;
public class BookingConfigurations : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable(nameof(Booking));
        builder.HasKey(b => b.Id);


        builder
            .HasMany(b => b.Tickets)
            .WithOne(t => t.Booking)
            .HasForeignKey(t => t.BookingId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(b => b.Passenger)
            .WithMany(p => p.Bookings)
            .HasForeignKey(b => b.PassengerId)
            .OnDelete(DeleteBehavior.Cascade);


        builder
            .HasOne(b => b.Payment)
            .WithOne(p => p.Booking)
            .HasForeignKey<Payment>(p => p.BookingId)
            .OnDelete(DeleteBehavior.NoAction);


        builder
            .Property(b => b.BookingDate)
            .HasColumnType<DateTime>("datetime")
            .IsRequired();
    }
}
