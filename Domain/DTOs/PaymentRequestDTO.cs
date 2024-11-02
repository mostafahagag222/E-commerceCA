using Newtonsoft.Json;

namespace Domain.DTOs
{
    public class PaymentRequestDto
    {
        [JsonProperty("order")]
        public PaymentDataDto PaymentDataDto { get; set; }
        [JsonProperty("paymentGateway")]
        public PaymentGatewayDto PaymentGateway { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; } = "en";
        [JsonProperty("customer")]
        public CustomerDto Customer { get; set; }
        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }
        [JsonProperty("cancelUrl")]
        public string CancelUrl { get; set; }
        [JsonProperty("notificationUrl")]
        public string NotificationUrl { get; set; }
        [JsonProperty("reference")]
        public ReferenceDto Reference { get; set; }
    }

    public class PaymentDataDto
    {
        [JsonProperty("id")]
        public string Guid { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; } = "KWD";
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; } = "test description";
    }
    public class ReferenceDto
    {
        [JsonProperty("id")]
        public string Id = "anyId";
    }

    public class PaymentGatewayDto
    {
        [JsonProperty("src")]
        public string Src { get; set; } = "knet";
    }

    public class CustomerDto
    {
        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }



}
