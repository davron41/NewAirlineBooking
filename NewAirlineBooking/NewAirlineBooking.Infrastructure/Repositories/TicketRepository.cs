using NewAirlineBooking.Domain.Entities;
using NewAirlineBooking.Domain.Interfaces;
using NewAirlineBooking.Infrastructure.Persistence;

namespace NewAirlineBooking.Infrastructure.Repositories;
internal sealed class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
{
    public TicketRepository(ApplicationDbContext context) : base(context)
    {
    }

    public List<Ticket> GetTicketByFlight(int flightId)
    {
        var ticket = _context.Tickets
             .Where(x => x.FlightId == flightId && x.IsReserved == false)
             .ToList();

        return ticket;

    }
}


