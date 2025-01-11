using NewAirlineBooking.Domain.Common;

namespace NewAirlineBooking.Domain.Entities;
public class Payment : EntityBase
{
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    public int BookingId { get; set; }
    public required virtual Booking Booking { get; set; }
}
