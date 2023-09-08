using System.Net;

namespace WeSociety.Core.Exceptions
{
    public class LoginException : CustomException
    {
        public LoginException() : base("LOGINERROR",HttpStatusCode.OK)
        {
        }
    }
}
