using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;

namespace InfraStructure.Repositories
{
    public class PaymentLogRepository : GenericRepository<PaymentLog>, IPaymentLogRepository
    {
        private readonly EcpContext _context;
        public PaymentLogRepository(EcpContext context) : base(context)
        {
            this._context = context;
        }
    }
}
