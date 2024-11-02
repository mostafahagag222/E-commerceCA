namespace Domain.DTOs
{
    public class GetAllOrdersDto
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}
