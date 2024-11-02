namespace Domain.DTOs
{
    public class AddOrderDto
    {
        public List<GetItemPriceDetailsDto> Items { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}
