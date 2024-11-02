namespace Domain.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public string BuyerEmail { get; set; }
        public AddressDto ShipAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
    }
}
