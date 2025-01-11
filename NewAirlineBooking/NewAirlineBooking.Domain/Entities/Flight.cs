using NewAirlineBooking.Domain.Common;

namespace NewAirlineBooking.Domain.Entities;
public class Flight : EntityBase
{
    public required string FlightNumber { get; set; }
    public required string DepartureLocation { get; set; }
    public string? ArrivalLocation { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public TimeSpan Duration { get; set; }
    public ICollection<Ticket> Tickets { get; set; }

    public Flight()
    {
        Tickets = new HashSet<Ticket>();
    }

}
