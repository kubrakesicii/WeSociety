using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.Exceptions
{
    public class NotfoundException : CustomException
    {
        public NotfoundException() : base("NOTFOUND",HttpStatusCode.NotFound)
        {
        }
    }
}
