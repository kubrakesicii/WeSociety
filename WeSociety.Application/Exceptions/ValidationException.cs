﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.Exceptions
{
    public class ValidationException : CustomException
    {
        public ValidationException(IReadOnlyDictionary<string, List<string>>? errors) : base("VALIDATIONEXCEPTION", HttpStatusCode.BadRequest, errors)
        {
        }
    }
}
