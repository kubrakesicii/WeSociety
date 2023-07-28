using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Domain.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(string id, string email, string username,int profileId);
        Task<List<Claim>> GetUserClaims();
    }
}
