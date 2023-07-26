using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.Exceptions
{
    public class UserExistsException : CustomException
    {
        public UserExistsException() : base("USEREXISTS", HttpStatusCode.OK)
        {
        }
    }
}
