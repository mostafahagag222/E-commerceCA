using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBasketItemRepository : IGenericRepository<BasketItem>
    {
        void DeleteRange(List<BasketItem> basketItemsToRemove);
        Task DeleteRangeByBasketId(string id);
        Task<BasketItem> GetBasketItemByBasketIdProductId(string basketId, int productId);
        Task<QuantityUnitsInStockDto> GetBasketItemQuantityAndUnitInStockAsync(string basketId, int basketItemId);
        Task<List<BasketItem>> GetBasketItemsFroSpecificBasket(string basketId);
        Task<BasketDto> GetBasketDtoAsync(string basketId);
        Task<List<CreateOrderItemDto>> GetBasketItemsDtoAsync(string basketId);
    }
}
