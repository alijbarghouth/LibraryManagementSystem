using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Authentication;
using WebApi.Features;
using WebApi.Settings;

namespace WebApi.Configurations;

public static class Configuration
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDistributedMemoryCache();
        services.AddSession
            (
                 option =>
                 {
                     option.IOTimeout = TimeSpan.FromMinutes(10);
                 }
            );
        services.AddSwaggerGen(options =>
         {
             options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
             {
                 Description = "Standard authorization header using the bearer scheme(\"bearer {token}\")",
                 In = ParameterLocation.Header,
                 Name = "Authorization",
                 Type = SecuritySchemeType.ApiKey
             });
             options.OperationFilter<SecurityRequirementsOperationFilter>();
         });
        services.AddScoped<LogoutMiddleware>();
        services.AddScoped<LoggerMiddleware>();

        services.Configure<JWT>(configuration.GetSection("JWT"));

        return services;
    }
}

