﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.Responses
{
    public class ErrorDataResponse<T> : DataResponse<T>
    {
        public ErrorDataResponse(string message) : base(default, false, message) { }

    }
}