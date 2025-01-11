using NewAirlineBooking.Domain.Entities;

namespace NewAirlineBooking.Domain.Interfaces;
public interface ITicketRepository : IRepositoryBase<Ticket>
{
    List<Ticket> GetTicketByFlight(int flightId);
}
