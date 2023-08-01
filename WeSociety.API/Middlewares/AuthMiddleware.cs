using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Application.Exceptions;
using WeSociety.Infrastructure.Authentication;

namespace WeSociety.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSetting _jwtSetting;


        public AuthMiddleware(RequestDelegate next, JwtSetting jwtSetting)
        {
            _next = next;
            _jwtSetting = jwtSetting;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_jwtSetting.SecurityKey);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);


                    if (validatedToken != null)
                    {
                        var jwtToken = (JwtSecurityToken)validatedToken;
                      
                        var id = jwtToken.Claims.First(x => x.Type.Equals("id")).Value;
                        var email = jwtToken.Claims.First(x => x.Type.Equals("email")).Value;
                        var username = jwtToken.Claims.First(x => x.Type.Equals("username")).Value;
                        var profileId = jwtToken.Claims.First(x => x.Type.Equals("profileId")).Value;

                        httpContext.Items["token"] = JsonConvert.SerializeObject(token);
                        await _next(httpContext);

                    }
                    else
                    {
                        //auth err
                    }
                } catch(Exception e) {
                    throw new AuthenticationException();
                }
            } else
            {
                await _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
