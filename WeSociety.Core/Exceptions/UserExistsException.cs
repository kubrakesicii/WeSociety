using System.Net;

namespace WeSociety.Core.Exceptions
{
    public class UserExistsException : CustomException
    {
        public UserExistsException() : base("USEREXISTS", HttpStatusCode.OK)
        {
        }
    }
}
