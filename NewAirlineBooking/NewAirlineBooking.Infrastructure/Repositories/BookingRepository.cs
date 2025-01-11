using Microsoft.EntityFrameworkCore;
using NewAirlineBooking.Domain.Entities;
using NewAirlineBooking.Domain.Interfaces;
using NewAirlineBooking.Infrastructure.Persistence;

namespace NewAirlineBooking.Infrastructure.Repositories;
internal sealed class BookingRepository : RepositoryBase<Booking>, IBookingRepository
{
    public BookingRepository(ApplicationDbContext context) : base(context)
    {
    }
    public List<Booking> GetAll(Guid UserId)
    {
        var bookings = _context.Bookings
             .AsNoTracking()
            .Where(x => x.Passenger.UserId == UserId)
            .Include(b => b.Tickets)
            .Include(b => b.Payment)
            .ToList();

        return bookings;
    }

}
