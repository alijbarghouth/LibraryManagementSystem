using Application.GenericRepositories;
using Domain.Authentication;
using Domain.Features.UserService.Services.AuthService;
using Domain.Features.UserService.Services.LoginService;
using Domain.Features.UserService.Services.RegisterService;
using Domain.Features.UserService.SharedRepositories;
using Domain.Shared.Exceptions;
using Infrastructure.Authentication;
using Infrastructure.DBContext;
using Infrastructure.Features.UserFeature.Repositories;
using Infrastructure.Features.UserFeature.SharedRepositories;
using Infrastructure.Model;
using Infrastructure.Repositories;
using Infrastructure.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations;

public static class Configuration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        AddLibraryDbContext(services, configuration);
        AddRedisConfig(services, configuration);
        AddCustomDependencies(services);
        AddMapsterConfiguration();
        return services;
    }
    private static void AddCustomDependencies(IServiceCollection services)
    {
        services.AddScoped<ILogoutRepository, RedisLogoutRepository>();
        services.AddScoped<IRegisterRepository, RegisterRepostiory>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<ISharedRepository, SharedRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
    }
    private static void AddLibraryDbContext(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<LibraryDBContext>(delegate (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(configuration.GetConnectionString("LibraryDbContext"));
        });
    }
    private static void AddRedisConfig(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddStackExchangeRedisCache(redisOption =>
        {
            string connectionString = configuration.GetConnectionString("Redis") ?? "";
            redisOption.Configuration = connectionString;
        });
    }
    private static void AddMapsterConfiguration()
    {
        TypeAdapterConfig<Domain.Features.UserService.DTOs.RegisterUser, User>
            .NewConfig()
            .Ignore(x => x.PasswordHash)
            .Ignore(x => x.PasswordSlot);
    }
}
