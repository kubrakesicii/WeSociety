using System.Net;

namespace WeSociety.Core.Exceptions
{
    public class ValidationException : CustomException
    {
        public ValidationException(IReadOnlyDictionary<string, List<string>>? errors) : base("VALIDATIONEXCEPTION", HttpStatusCode.BadRequest, errors)
        {
        }
    }
}
