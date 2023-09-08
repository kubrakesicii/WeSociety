namespace WeSociety.Core.Responses
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Response(bool success)
        {
            Success = success;
            Message = string.Empty;
        }

        public Response(bool success, string message) : this(success)
        {
            Message = message;
        }
    }
}
