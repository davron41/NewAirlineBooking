using Microsoft.EntityFrameworkCore;
using NewAirlineBooking.Domain.Entities;
using NewAirlineBooking.Domain.Interfaces;
using NewAirlineBooking.Infrastructure.Persistence;

namespace NewAirlineBooking.Infrastructure.Repositories;
internal sealed class FlightRepository : RepositoryBase<Flight>, IFlightRepository
{
    public FlightRepository(ApplicationDbContext context) : base(context)
    {
    }

    public List<Flight> GetAllByDate(DateTime date)
    {
        var flights = _context.Flights
            .Where(f => f.DepartureTime.Date == date)
            .AsNoTracking()
            .ToList();

        return flights;
    }
}
