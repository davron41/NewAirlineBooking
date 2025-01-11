using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewAirlineBooking.Domain.Entities;

namespace NewAirlineBooking.Infrastructure.Persistence.Configurations;
public class PassengerConfigurations : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.ToTable(nameof(Passenger));
        builder.HasKey(p => p.Id);


        builder
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        builder
            .HasMany(p => p.Bookings)
            .WithOne(b => b.Passenger)
            .HasForeignKey(b => b.PassengerId)
            .OnDelete(DeleteBehavior.Cascade);


        builder
            .Property(p => p.Name)
            .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
            .IsRequired();

        builder
            .Property(p => p.Surname)
            .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
            .IsRequired();


        builder
            .Property(p => p.PhoneNumber)
            .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
            .IsRequired();


        builder
            .Property(p => p.PassportNumber)
            .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
            .IsRequired();
    }
}
