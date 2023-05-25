using Application.Repositories;
using Infrastructure.DBContext;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations;

public static class Configuration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDBContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
               );
        services.AddStackExchangeRedisCache(redisOption =>
        {
            string connectionString = configuration.GetConnectionString("Redis");
            redisOption.Configuration = connectionString;

        });
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        return services;
    }
}
