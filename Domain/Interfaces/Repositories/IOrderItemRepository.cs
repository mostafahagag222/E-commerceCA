using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task TransferBasketItemsToOrderItemsAsync(string basketId);
    }
}
