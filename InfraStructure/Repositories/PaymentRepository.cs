using Domain;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly EcpContext _context;
        public PaymentRepository(EcpContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<HandlePaymentPaymentDataDto> GetHandlePaymentPaymentDataDto(string gUid)
        {
            var result = await _context.Payments
                .Where(p => p.UniqueIdentifier == gUid)
                .Select(p => new HandlePaymentPaymentDataDto
                {
                    BasketId = p.BasketId,
                    PaymentId = p.Id,
                    UserId = p.UserId,
                    Amount = p.Amount
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateOrderId(int orderId, string gUid)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.UniqueIdentifier == gUid);
            payment.OrderId = orderId;
        }

        public async Task UpdateStatusAsync(string gUid, PaymentStatus status)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.UniqueIdentifier == gUid);
            payment.Status = status;
            payment.UpdatedAt = DateTime.Now;
            _context.Payments.Update(payment);
        }

    }
}
