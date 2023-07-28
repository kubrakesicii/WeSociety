using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.Exceptions
{
    public class AuthenticationException : CustomException
    {
        public AuthenticationException() : base("UNAUTHORIZED", HttpStatusCode.Unauthorized)
        {
        }
    }
}
