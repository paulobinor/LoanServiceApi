namespace LoanServiceApi.Models
{
    public class ApiRequest
    {
        public string ResponseCode { get; set; }
        public string RequestId { get; set; } = string.Empty;
        public string ResponseDescription { get; set; } = string.Empty;
        public object Data { get; set; }

    }
}
