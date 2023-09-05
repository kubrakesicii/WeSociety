using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Interfaces;
using WeSociety.Infrastructure.Authentication;

namespace WeSociety.Infrastructure.ServiceRegistrations
{
    public static class JwtRegistration
    {
        public static void AddJwtService(this IServiceCollection services, IConfiguration config)
        {
            //JWT SETTINGS
            var jwtSettings = new JwtSetting
            {
                Issuer = "wesociety",
                Audience = "wesociety",
                SecurityKey = config["JWT_SECURITY_KEY"],
                AccessTokenExpiration = 60 * 24 * 7    ///7 DAYS
            };
            services.AddSingleton(jwtSettings);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddHttpContextAccessor();
            services.AddScoped<IJwtService, JwtService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

    }
}
