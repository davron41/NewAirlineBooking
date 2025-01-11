using NewAirlineBooking.Domain.Entities;
using NewAirlineBooking.Domain.Interfaces;
using NewAirlineBooking.Infrastructure.Persistence;

namespace NewAirlineBooking.Infrastructure.Repositories;
internal sealed class PassengerRepository : RepositoryBase<Passenger>, IPassengerRepository
{
    public PassengerRepository(ApplicationDbContext context) : base(context)
    {
    }
}
