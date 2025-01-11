using NewAirlineBooking.Domain.Entities;

namespace NewAirlineBooking.Domain.Interfaces;
public interface IPaymentRepository : IRepositoryBase<Payment>
{
    List<Payment> GetPayments(Guid UserId);
}
