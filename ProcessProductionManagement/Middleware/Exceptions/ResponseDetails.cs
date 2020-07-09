namespace PPM.Api.Middleware
{
    public class ResponseDetails
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public uint ErrorCode { get; set; }
    }
}