
namespace Domain.DTOs
{
    public class CreateRequestBodyDto
    {
        public PaymentRequestDto RequestBody { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Guid { get; set; }
    }
}