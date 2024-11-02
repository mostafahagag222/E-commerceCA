using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly EcpContext _context;
        public OrderRepository(EcpContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<GetAllOrdersDto>> GetAllOrdersDto(int userId)
        {
            var result = await _context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new GetAllOrdersDto()
                {
                    Id = o.Id,
                    OrderDate = o.Updated.ToString(),
                    Status = o.OrderStatus.ToString(),
                    Total = o.TotalPrice
                }).ToListAsync();
            return result;
        }

        public async Task<OrderDto> GetOrderDetailsById(int orderId)
        {
            var order = await _context.Orders
                .Where(o => o.Id == orderId)
                .Select(o => new OrderDto()
                {
                    DeliveryMethod = o.ShippingMethod != null ? o.ShippingMethod.Name : "ass",
                    ShippingPrice = o.ShippingMethod != null ? o.ShippingMethod.Price : 12,
                    Subtotal = o.SubTotal,
                    OrderDate = o.Updated.ToString(),
                    Id = o.Id,
                    Status = o.OrderStatus.ToString(),
                    Total = o.TotalPrice,
                    BuyerEmail = o.User.Email,
                    ShipAddress = o.User.Addresses.Select(a => new AddressDto()
                    {
                        City = a.City,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        State = a.State,
                        Street = a.Street,
                        ZipCode = a.ZipCode
                    }).FirstOrDefault(),
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto()
                    {
                        PictureUrl = oi.Product.ImageUrl,
                        Price = oi.Product.Price,
                        ProductId = oi.ProductId,
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity
                    }).ToList(),

                }).FirstOrDefaultAsync();
            return order;
        }

        public async Task<int> GetOrderId(string basketId)
        {
            return await _context.Orders.Where(o => o.BasketId == basketId).Select(o => o.Id).FirstOrDefaultAsync();
        }
    }
}
