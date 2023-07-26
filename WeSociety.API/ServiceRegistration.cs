using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using WeSociety.API.Middlewares;

namespace WeSociety.API
{
    public static class ServiceRegistration
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            //SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"TEST API V1",
                    Version = "v1.0",
                    Description = ".NET Core 6.0.100",
                    TermsOfService = new Uri("https://Example.com/terms"),
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://example.com/license")
                    }
                });


                // c.OperationFilter<SwaggerHeaderParameter>();

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization by using Bearer Scheme. For example: \"Authorization: Bearer {token}\"",
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
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Api ServiceV2");
                //c.DefaultModelsExpandDepth(-1);
                //c.DocExpansion(DocExpansion.None);
            });

            //MIDDLEWARES
            app.UseCustomExceptionMiddleware();

            app.MapControllers();
            app.Run();
        }
    }
}
