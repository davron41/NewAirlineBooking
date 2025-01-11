using NewAirlineBooking.Domain.Interfaces;
using NewAirlineBooking.Infrastructure.Persistence;

namespace NewAirlineBooking.Infrastructure.Repositories;
internal sealed class CommonRepository : ICommonRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IFlightRepository _flights;
    public IFlightRepository Flights => _flights;

    private readonly IBookingRepository _bookings;
    public IBookingRepository Bookings => _bookings;

    private readonly IPassengerRepository _passengers;
    public IPassengerRepository Passes => _passengers;

    private readonly ITicketRepository _tickets;
    public ITicketRepository Tickets => _tickets;

    private readonly IPaymentRepository _payments;
    public IPaymentRepository Payments => _payments;


    public CommonRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _flights = new FlightRepository(context);
        _bookings = new BookingRepository(context);
        _tickets = new TicketRepository(context);
        _passengers = new PassengerRepository(context);
        _payments = new PaymentRepository(context);
    }
    public int SaveChanges()
              => _context.SaveChanges();
}
