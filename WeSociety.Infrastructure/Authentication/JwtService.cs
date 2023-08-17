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

namespace WeSociety.Infrastructure.Authentication
{
    public class JwtService : IJwtService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSetting _jwtSetting;

        public JwtService(IHttpContextAccessor httpContextAccessor, JwtSetting jwtSetting)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSetting = jwtSetting;
        }

        public string CreateToken(string id, string email, string username, int profileId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecurityKey));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwt = CreateJwtSecurityToken(id, email, username, profileId, signingCredentials);
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

        private JwtSecurityToken CreateJwtSecurityToken(string id, string email, string username, int profileId,SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                "",
                "",
                expires: DateTime.Now.AddMinutes(_jwtSetting.AccessTokenExpiration),
                notBefore: DateTime.Now,
                claims: new List<Claim>
                {
                    new Claim("id", id),
                    new Claim("email", email),
                    new Claim("username", username),
                    new Claim("profileId", profileId.ToString())
                },
                signingCredentials: signingCredentials
            );
            return jwt;
        }
    }
}
