namespace Domain.DTOs
{
    public class HandlePaymentPaymentDataDto
    {
        public int PaymentId { get; set; }
        public int? UserId { get; set; }
        public string BasketId { get; set; }
        public decimal Amount { get; set; }
    }
}