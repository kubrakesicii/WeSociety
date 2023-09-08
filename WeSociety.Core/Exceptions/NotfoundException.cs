using System.Net;

namespace WeSociety.Core.Exceptions
{
    public class NotfoundException : CustomException
    {
        public NotfoundException() : base("NOTFOUND",HttpStatusCode.NotFound)
        {
        }
    }
}
