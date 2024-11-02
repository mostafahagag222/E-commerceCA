namespace Domain.DTOs
{
    public class GetPaymentAmountDto
    {
        public decimal ShippingPrice { get; set; }
        public List<GetItemPriceDetailsDto> BasketItemsWithProductPrices { get; set; }
    }
}