using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
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

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = configuration.GetSection("JWT:Issuer").Value,
            ValidAudience = configuration.GetSection("JWT:Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWT:Key").Value ?? "")),
            ClockSkew = TimeSpan.Zero
        };
    });
        services.AddScoped<LogoutMiddleware>();
        services.AddScoped<LoggerMiddleware>();

        services.Configure<JWT>(configuration.GetSection("JWT"));

        return services;
    }
}

