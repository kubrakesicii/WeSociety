using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.Exceptions
{
    public class LoginException : CustomException
    {
        public LoginException() : base("LOGINERROR",HttpStatusCode.OK)
        {
        }
    }
}
