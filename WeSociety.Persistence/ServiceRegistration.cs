using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.AggregateRoots.Users;
using WeSociety.Domain.Interfaces;
using WeSociety.Domain.Repository;
using WeSociety.Persistence.Authentication;
using WeSociety.Persistence.Context;
using WeSociety.Persistence.Repositories;

namespace WeSociety.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<WeSocietyDbContext>(options =>
            {
                options.UseSqlServer($"Server={config["DB_SERVER"]}; Database={config["DB_NAME"]}; Trusted_Connection=True;TrustServerCertificate=True;");
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddIdentity<AppUser, IdentityRole>(_ =>
            {
                _.User.RequireUniqueEmail = true;  //username param default unique'dir.
            })
                .AddEntityFrameworkStores<WeSocietyDbContext>();



            //JWT SETTINGS
            var jwtSettings = new JwtSetting
            {
                Issuer = "healandmoreacademy.com",
                Audience = "healandmoreacademy.com",
                SecurityKey = config["JWT_SECURITY_KEY"],
                AccessTokenExpiration = 60 * 60 * 24 * 7    ///7 DAYS
            };
            services.AddSingleton(jwtSettings);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "",
                    ValidAudience = "",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
