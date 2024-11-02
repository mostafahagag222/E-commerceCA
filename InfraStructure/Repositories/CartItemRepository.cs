using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public class BasketItemRepository : GenericRepository<BasketItem>, IBasketItemRepository
    {
        private readonly EcpContext _context;

        public BasketItemRepository(EcpContext context) : base(context)
        {
            this._context = context;
        }

        public void DeleteRange(List<BasketItem> basketItemsToRemove)
        {
            _context.RemoveRange(basketItemsToRemove);
        }

        public async Task DeleteRangeByBasketId(string id)
        {
            var basketItems = await _context.BasketItems.Where(ci => ci.BasketId == id).ToListAsync();
            _context.BasketItems.RemoveRange(basketItems);
        }

        public async Task<BasketItem> GetBasketItemByBasketIdProductId(string basketId, int productId)
        {
            return await (from ci in _context.BasketItems
                where ci.BasketId == basketId
                      && ci.ProductId == productId
                select ci).FirstOrDefaultAsync();
        }

        public async Task<QuantityUnitsInStockDto> GetBasketItemQuantityAndUnitInStockAsync(string basketId,
            int basketItemId)
        {
            return await (from ci in _context.BasketItems
                where ci.BasketId == basketId
                      && ci.Id == basketItemId
                join p in _context.Products
                    on ci.ProductId equals p.Id
                select new QuantityUnitsInStockDto()
                {
                    BasketItemQuantity = ci.Quantity,
                    ProdutcStockQuantity = p.UnitsInStock
                }).FirstOrDefaultAsync();
        }

        public async Task<List<BasketItem>> GetBasketItemsFroSpecificBasket(string basketId)
        {
            return await (from ci in _context.BasketItems
                where ci.BasketId == basketId
                select ci).ToListAsync();
        }

        public async Task<BasketDto> GetBasketDtoAsync(string basketId)
        {
            var requiredBasket = await _context.Baskets
                .Where(c => c.Id == basketId)
                .Include(c => c.BasketItems)
                .ThenInclude(ci => ci.Product)
                .Select(c => new BasketDto()
                {
                    Id = c.Id,
                    DeliveryMethodId = c.ShippingMethodId != null ? int.Parse(c.ShippingMethodId) : 0,
                    ShippingPrice = c.ShippingMethod != null ? c.ShippingMethod.Price : 0,
                    Items = c.BasketItems.Select(c => new ProductDto()
                    {
                        Id = c.Product.Id,
                        Price = c.Product.Price,
                        BrandId = c.Product.BrandId,
                        Description = c.Product.Description,
                        Name = c.Product.Name,
                        PictureUrl = c.Product.ImageUrl,
                        Quantity = c.Quantity,
                        TypeId = c.Product.TypeId,
                        UnitsInStock = c.Product.UnitsInStock
                    }).ToList()
                }).FirstOrDefaultAsync();
            return requiredBasket;
        }

        public async Task<List<CreateOrderItemDto>> GetBasketItemsDtoAsync(string basketId)
        {
            var items = await (from ci in _context.BasketItems
                where ci.BasketId == basketId
                select new CreateOrderItemDto()
                {
                    Product = ci.Product,
                    Quantity = ci.Quantity,
                    TotalPrice = ci.Quantity * ci.Product.Price,
                    Price = ci.Price
                }).ToListAsync();
            return items;
        }
    }
}