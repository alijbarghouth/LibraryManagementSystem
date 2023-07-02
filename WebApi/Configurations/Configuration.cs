using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;
using System.IO.Compression;
using System.Text;
using WebApi.Filter;
using WebApi.Middleware;

namespace WebApi.Configurations;

public static class Configuration
{
    public static void AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options =>
        {
            options.ReturnHttpNotAcceptable = true;
            options.Filters.Add<ModelStateFilter>();
        }).AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }).AddXmlDataContractSerializerFormatters();

        services.AddScoped<LoggerMiddleware>();
        services.AddDistributedMemoryCache();
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

        services.AddCors(c =>
        {
            c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().
             AllowAnyHeader());
        });

        services.AddHealthChecks();

        services.AddResponseCompression(option =>
        {
            option.EnableForHttps = true;
        });

        services.Configure<BrotliCompressionProviderOptions>(option =>
        {
            option.Level = CompressionLevel.Fastest;
        });
    }
}

