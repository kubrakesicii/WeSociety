using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Infrastructure.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated => _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public string Id => _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Equals("id"))?.Value;

        public string FullName => _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Equals("fullname"))?.Value;
        public string Email => _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Equals("email"))?.Value;
    }
}
