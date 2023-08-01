using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using WeSociety.API.Middlewares;

namespace WeSociety.API
{
    public static class ServiceRegistration
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddDefaultPolicy(builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddMvc(opt => opt.EnableEndpointRouting=false);

            //SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"WeSociety API",
                    Version = "v1.0",
                    Description = ".NET Core 7.0.304"
                });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description ="JWT Authorization by using Bearer Scheme. For example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
                c.AddSecurityRequirement(securityRequirement);
            });

        }

        public static void ConfigureApiServices(this WebApplication app)
        {

            app.UseCors();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();


            //SWAGGER
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api ServiceV1");
                c.DefaultModelsExpandDepth(-1);
                c.DocExpansion(DocExpansion.None);
            });

            //MIDDLEWARES

            //Bu midde her istekte gidecek, token geldiyse claimse ilgili user bilgileri atanacak, gelmediyse boş olacak
            app.UseWhen(httpContext => (!httpContext.Request.Path.Equals("/Auth/Login") &&
            !httpContext.Request.Path.Equals("/Auth/Register")),
            subApp => subApp.UseAuthMiddleware());


            app.UseCustomExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
