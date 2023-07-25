using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Interfaces;

namespace WeSociety.Persistence.Authentication
{
    public class JwtService : IJwtService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreateToken(string id, string email, string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT_SECURITY_KEY"));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwt = CreateJwtSecurityToken(id, email, username, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return token;
        }

        public async Task<List<Claim>> GetUserClaims()
        {
            return await Task.Run(() =>
               new List<Claim>
               {
                     _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier),
                     _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)
               }
           );
        }

        private JwtSecurityToken CreateJwtSecurityToken(string id, string email, string username, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                "",
                "",
                expires: DateTime.Now.AddHours(1),
                notBefore: DateTime.Now,
                claims: new List<Claim>
                {
                    new Claim("id", id),
                    new Claim("email", email),
                    new Claim("username", username),
                },
                signingCredentials: signingCredentials
            );
            return jwt;
        }
    }
}
