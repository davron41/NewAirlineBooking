using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewAirlineBooking.Domain.Entities;

namespace NewAirlineBooking.Infrastructure.Persistence.Configurations;
public class TicketConfigurations : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable(nameof(Ticket));
        builder.HasKey(t => t.Id);


        builder
            .HasOne(t => t.Booking)
            .WithMany(b => b.Tickets)
            .HasForeignKey(t => t.BookingId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(t => t.Flight)
            .WithMany(f => f.Tickets)
            .HasForeignKey(t => t.FlightId)
            .OnDelete(DeleteBehavior.Cascade);


        builder
            .Property(t => t.SeatNumber)
            .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
            .IsRequired();

        builder
            .Property(t => t.IsReserved)
            .HasDefaultValue(false)
            .IsRequired();

    }


}
