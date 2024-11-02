namespace Domain.DTOs
{
    public class BasketDto
    {
        public string Id { get; set; }
        public decimal ShippingPrice { get; set; }
        public int DeliveryMethodId { get; set; }
        public List<ProductDto> Items { get; set; }
    }
}
