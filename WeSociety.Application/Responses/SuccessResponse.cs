using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.Responses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse() : base(true, "OK") { }
        public SuccessResponse(string message) : base(true, message) { }
    }
}
