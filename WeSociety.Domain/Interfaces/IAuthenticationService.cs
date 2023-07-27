using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }
        string Id { get; }
        string FullName { get; }
        string Email { get; }
    }
}
