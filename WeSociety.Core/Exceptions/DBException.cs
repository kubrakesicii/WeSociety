using System.Net;

namespace WeSociety.Core.Exceptions
{
    public class DBException : CustomException
    {
        public DBException() : base("DBCHANGEEXCEPTION",HttpStatusCode.InternalServerError)
        {
        }
    }
}
