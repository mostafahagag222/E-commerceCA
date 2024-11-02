using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        private readonly EcpContext _context;

        public BasketRepository(EcpContext context) : base(context)
        {
            this._context = context;
        }
        public async Task AddDeliveryMethodAsync(string id, int deliveryMethodId)
        {
            await _context.Baskets.Where(c => c.Id == id).ExecuteUpdateAsync(c => c.SetProperty(c => c.ShippingMethodId, deliveryMethodId.ToString()));
        }
        public async Task AddGuidToBasket(string basketId, string gUid)
        {
            await _context.Baskets.Where(c => c.Id == basketId)
                .ExecuteUpdateAsync(c => c
                .SetProperty(c => c.Guid, gUid));
        }
        public async Task<bool> DoesBasketExist(string id)
        {
            return await _context.Baskets.AnyAsync(c => c.Id == id);
        }
        public async Task DeleteBasketAsync(string id)
        {
            var basket = await _context.Baskets.FirstOrDefaultAsync(c => c.Id == id);
            _context.Remove(basket);
        }
        public async Task<GetPaymentAmountDto> GetProductAndBasketItemPrices(string basketId)
        {
            var result = await (from c in _context.Baskets
                                where c.Id == basketId
                                select new GetPaymentAmountDto
                                {
                                    ShippingPrice = c.ShippingMethod.Price,
                                    BasketItemsWithProductPrices = c.BasketItems.Select(ci => new GetItemPriceDetailsDto()
                                    {
                                        BasketItemPrice = ci.Price,
                                        ProductId = ci.ProductId,
                                        ProductPrice = ci.Product.Price,
                                        Quantity = ci.Quantity,
                                        TotalPrice = ci.TotalPrice
                                    }).ToList()
                                }
                                ).FirstOrDefaultAsync();
            return result;
        }
        public async Task<ShippingMethodIdAndSubtotalDto> GetSmIdAndSubTotalAsync(string basketId)
        {
            var result = await (from c in _context.Baskets
                                where c.Id == basketId
                                select new ShippingMethodIdAndSubtotalDto()
                                {
                                    ShippingMethodId = c.ShippingMethodId,
                                    Subtotal = c.BasketItems.Sum(ci => ci.Quantity * ci.Quantity)
                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateBasketAfterAddingBasketItemAsync(string basketId, decimal itemPrice)
        {
            return await _context
                .Baskets
                .Where(c => c.Id == basketId)
                .ExecuteUpdateAsync(c => c
                .SetProperty(c => c.UpdatedDate, DateTime.Now)
                .SetProperty(c => c.TotalPrice, c => c.TotalPrice + itemPrice)
                .SetProperty(c => c.TotalQuantity, c => c.TotalQuantity + 1)
                ) > 0;
        }
        public async Task<bool> UpdateBasketAfterRemovingBasketItemAsync(string basketId, decimal itemPrice)
        {
            return await _context
                .Baskets
                .Where(c => c.Id == basketId)
                .ExecuteUpdateAsync(c => c
                .SetProperty(c => c.UpdatedDate, DateTime.Now)
                .SetProperty(c => c.TotalPrice, c => c.TotalPrice - itemPrice)
                .SetProperty(c => c.TotalQuantity, c => c.TotalQuantity - 1)
                ) > 0;
        }

    }
}
