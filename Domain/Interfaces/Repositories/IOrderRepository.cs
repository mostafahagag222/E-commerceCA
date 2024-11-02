using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<GetAllOrdersDto>> GetAllOrdersDto(int userId);
        Task<OrderDto> GetOrderDetailsById(int orderId);
        Task<int> GetOrderId(string basketId);
    }
}
