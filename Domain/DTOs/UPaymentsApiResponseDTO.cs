namespace Domain.DTOs
{
    public class UPaymentsApiResponseDto
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public ResponseData Data { get; set; }
    }

    public class ResponseData
    {
        public string Link { get; set; }
    }
}
