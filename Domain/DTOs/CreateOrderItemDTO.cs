using Domain.Entities;

namespace Domain.DTOs
{
    public class CreateOrderItemDto
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Product Product { get; set; }

    }
}
