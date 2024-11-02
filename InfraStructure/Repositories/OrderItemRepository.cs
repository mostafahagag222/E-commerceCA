using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;

namespace InfraStructure.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly EcpContext _context;
        public OrderItemRepository(EcpContext context) : base(context)
        {
            this._context = context;
        }

        public async Task TransferBasketItemsToOrderItemsAsync(string basketId)
        {
            /*
 * fetch basket items in basketitemdto{including price from product} 11
 * map them into order items
 * add them to order items
 * update order after each add
 * convert basket items to order items with product current price
 * give them the created orderid
 */

            //var ToBeAddedOrderItems = orderDto.items.Select(c => new OrderItem
            //{
            //    OrderId = c.OrderId,
            //    Quantity = c.Quantity,
            //    TotalPrice = c.TotalPrice,
            //    ProductId = c.ProductId,
            //    Price = c.ProductPrice,
            //    OrderTotalPrice = 0
            //}).ToList();
            //await context.OrderItems.AddRangeAsync(ToBeAddedOrderItems);
            //var orderId = orderDto.items.Select(c => c.ProductId).FirstOrDefault();
            //var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            //order.Updated = DateTime.Now;
            //order.TotalPrice = ToBeAddedOrderItems.Sum(t => t.TotalPrice) + orderDto.ShippingFees;
            //order.TotalQuantity = ToBeAddedOrderItems.Sum(t => t.Quantity);
            //context.Update(order);
            throw new Exception();
        }
    }
}
