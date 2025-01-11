namespace NewAirlineBooking.Domain.Interfaces;
public interface ICommonRepository
{
    public IFlightRepository Flights { get; }
    public IBookingRepository Bookings { get; }
    public IPassengerRepository Passes { get; }
    public ITicketRepository Tickets { get; }
    public IPaymentRepository Payments { get; }

    public int SaveChanges();
}
