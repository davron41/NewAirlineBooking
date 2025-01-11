using NewAirlineBooking.Domain.Entities;

namespace NewAirlineBooking.Domain.Interfaces;
public interface IFlightRepository
{
    List<Flight> GetAllByDate(DateTime date);
}
