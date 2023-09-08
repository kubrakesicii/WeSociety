using System.Net;

namespace WeSociety.Core.Exceptions
{
    public class AuthenticationException : CustomException
    {
        public AuthenticationException() : base("UNAUTHORIZED", HttpStatusCode.Unauthorized)
        {
        }
    }
}
