using Microsoft.EntityFrameworkCore;
using NewAirlineBooking.Domain.Entities;
using NewAirlineBooking.Domain.Interfaces;
using NewAirlineBooking.Infrastructure.Persistence;

namespace NewAirlineBooking.Infrastructure.Repositories;
internal sealed class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
{
    public PaymentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public List<Payment> GetPayments(Guid userId)
    {
        var payments = _context.Payments
            .AsNoTracking()
            .Where(x => x.Booking.Passenger.UserId == userId)
            .ToList();

        return payments;
    }

}
