using NewAirlineBooking.Domain.Common;

namespace NewAirlineBooking.Domain.Entities;
public class Booking : EntityBase
{
    public DateTime BookingDate { get; set; }
    public int PassengerId { get; set; }
    public required virtual Passenger Passenger { get; set; }
    public required virtual Payment Payment { get; set; }

    public ICollection<Ticket> Tickets { get; set; }

    public Booking()
    {
        Tickets = new HashSet<Ticket>();
    }

}
