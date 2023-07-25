using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IReadOnlyDictionary<string, List<string>> Errors { get; set; }
        public ValidationException(IReadOnlyDictionary<string, List<string>> errors) : base("VALIDATIONEXCEPTION")
        {
            Errors = errors;
        }
    }
}
