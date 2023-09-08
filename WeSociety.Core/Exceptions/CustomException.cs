using System.Net;

namespace WeSociety.Core.Exceptions
{
    public class CustomException : Exception
    {

        public string Message { get; set; }
        public IReadOnlyDictionary<string, List<string>>? Errors { get; }
        public HttpStatusCode StatusCode { get; set; }

        public CustomException(string message, HttpStatusCode statusCode, IReadOnlyDictionary<string, List<string>>? errors)
        {
            Message = message;
            StatusCode = statusCode;
            Errors = errors;
        }

        public CustomException(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
