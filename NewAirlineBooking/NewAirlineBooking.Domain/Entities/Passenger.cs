using Microsoft.AspNetCore.Identity;
using NewAirlineBooking.Domain.Common;

namespace NewAirlineBooking.Domain.Entities;
public class Passenger : EntityBase
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string PassportNumber { get; set; }
    public Guid UserId { get; set; }
    public required IdentityUser<Guid> User { get; set; }
    public ICollection<Booking> Bookings { get; set; }

    public Passenger()
    {
        Bookings = new List<Booking>();
    }
}
