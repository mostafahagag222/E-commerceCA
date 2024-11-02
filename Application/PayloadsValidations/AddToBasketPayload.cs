﻿namespace Application.PayloadsValidations
{
    public class UpdateBasketPayload
    {
        public string Id { get; set; }
        public decimal ShippingPrice {  get; set; }
        public int DeliveryMethodId { get; set; }
        public List<BasketItemPayload> Items { get; set; }
    }
}
