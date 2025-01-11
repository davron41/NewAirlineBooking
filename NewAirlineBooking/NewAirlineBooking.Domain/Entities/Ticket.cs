using NewAirlineBooking.Domain.Common;

namespace NewAirlineBooking.Domain.Entities;
public class Ticket : EntityBase
{
    public int BookingId { get; set; }
    public int FlightId { get; set; }
    public required string SeatNumber { get; set; }
    public bool IsReserved { get; set; }

    public required virtual Booking Booking { get; set; }
    public required virtual Flight Flight { get; set; }
}
