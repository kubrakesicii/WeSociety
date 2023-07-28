using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        //Task<string> GetId();
        //Task<string> GetEmail();
        //Task<string> GetUserName();
        //Task<int> GetProfileId();
        //bool IsAuthenticated { get; }

        bool IsAuthenticated { get; }
        string Id { get; }
        string Email { get; }
        string Username { get; }
        Task<int> GetProfileId();
    }
}
