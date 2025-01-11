using NewAirlineBooking.Domain.Entities;

namespace NewAirlineBooking.Domain.Interfaces;
public interface IBookingRepository : IRepositoryBase<Booking>
{
    List<Booking> GetAll(Guid UserId);

}
