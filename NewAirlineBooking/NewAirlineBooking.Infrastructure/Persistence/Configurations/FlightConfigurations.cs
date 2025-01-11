using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewAirlineBooking.Domain.Entities;

namespace NewAirlineBooking.Infrastructure.Persistence.Configurations;
public class FlightConfigurations : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {

        builder.ToTable(nameof(Flight));
        builder.HasKey(f => f.Id);

        builder
            .HasMany(f => f.Tickets)
            .WithOne(t => t.Flight)
            .HasForeignKey(t => t.FlightId)
            .OnDelete(DeleteBehavior.Cascade);


        builder
            .Property(f => f.FlightNumber)
            .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
            .IsRequired();

        builder
            .Property(f => f.DepartureLocation)
            .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
            .IsRequired();

        builder
            .Property(f => f.ArrivalLocation)
            .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
            .IsRequired();

        builder
            .Property(f => f.DepartureTime)
            .HasColumnType<DateTime>("datetime")
            .IsRequired();

        builder
            .Property(f => f.ArrivalTime)
            .HasColumnType<DateTime>("datetime");


        builder
            .Property(f => f.Duration)
            .HasColumnType<TimeSpan>("time")
            .IsRequired();


    }
}
