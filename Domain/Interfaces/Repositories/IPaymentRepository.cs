using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<HandlePaymentPaymentDataDto> GetHandlePaymentPaymentDataDto(string gUid);
        Task UpdateOrderId(int orderId, string gUid);
        Task UpdateStatusAsync(string gUid, PaymentStatus successfulPayment);
    }
}
