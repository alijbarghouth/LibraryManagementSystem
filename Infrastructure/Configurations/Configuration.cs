using Domain.Authentication;
using Infrastructure.Authentication;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations;

public static class Configuration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                 );
        services.AddScoped<ILogoutRepository, RedisLogoutRepository>();

        services.AddScoped<ILogoutRepository>(provider =>
        {
            var cache = provider.GetRequiredService<IDistributedCache>();
            var tokenLifetime = Convert.ToDouble(configuration.GetSection("Security:TokenLifetime").Value);
            return new RedisLogoutRepository(cache, tokenLifetime);
        });

        return services;
    }
}
