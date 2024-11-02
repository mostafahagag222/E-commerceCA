using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        Task AddDeliveryMethodAsync(string id, int deliveryMethodId);
        Task AddGuidToBasket(string basketId, string gUid);
        Task<bool> DoesBasketExist(string id);
        Task DeleteBasketAsync(string id);
        Task<GetPaymentAmountDto> GetProductAndBasketItemPrices(string basketId);
        Task<ShippingMethodIdAndSubtotalDto> GetSmIdAndSubTotalAsync(string basketId);
        Task<bool> UpdateBasketAfterAddingBasketItemAsync(string basketId, decimal itemPrice);
        Task<bool> UpdateBasketAfterRemovingBasketItemAsync(string basketId, decimal itemPrice);
    }
}
