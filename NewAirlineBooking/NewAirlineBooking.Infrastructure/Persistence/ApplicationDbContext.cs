using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewAirlineBooking.Domain.Entities;
using System.Reflection;

namespace NewAirlineBooking.Infrastructure.Persistence;
public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public virtual DbSet<Passenger> Passengers { get; set; }
    public virtual DbSet<Flight> Flights { get; set; }
    public virtual DbSet<Ticket> Tickets { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);

        #region Identity

        builder.Entity<IdentityUser<Guid>>(e =>
        {
            e.ToTable("User");

        });

        builder.Entity<IdentityUserClaim<Guid>>(e =>
        {
            e.ToTable("UserClaim");
        });

        builder.Entity<IdentityUserLogin<Guid>>(e =>
        {
            e.ToTable("UserLogin");
        });

        builder.Entity<IdentityUserToken<Guid>>(e =>
        {
            e.ToTable("UserToken");
        });

        builder.Entity<IdentityRole<Guid>>(e =>
        {
            e.ToTable("Role");
        });

        builder.Entity<IdentityRoleClaim<Guid>>(e =>
        {
            e.ToTable("RoleClaim");
        });

        builder.Entity<IdentityUserRole<Guid>>(e =>
        {
            e.ToTable("UserRole");
        });

        #endregion
    }
}
