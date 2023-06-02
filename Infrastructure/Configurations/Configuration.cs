using Domain.Authentication;
using Domain.DTOs.UserDTOs;
using Domain.Repositories.AuthorRepository;
using Domain.Repositories.BookAuthorRepository;
using Domain.Repositories.BookRepository;
using Domain.Repositories.GenreRepository;
using Domain.Repositories.ReserveBookRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions;
using Infrastructure.Authentication;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Infrastructure.Repositories.AuthorRepository;
using Infrastructure.Repositories.BookAuthorRepository;
using Infrastructure.Repositories.BookRepository;
using Infrastructure.Repositories.GenreRepository;
using Infrastructure.Repositories.BookTransactionRepository;
using Infrastructure.Repositories.SharedRepositories;
using Infrastructure.Repositories.UserRepositories;
using Infrastructure.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Settings;

namespace Infrastructure.Configurations;

public static class Configuration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        AddLibraryDbContext(services, configuration);
        AddRedisConfig(services, configuration);
        AddCustomDependencies(services, configuration);
        AddMapsterConfiguration();
        return services;
    }
    private static void AddCustomDependencies(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<ILogoutRepository, RedisLogoutRepository>();
        services.AddScoped<IRegisterRepository, RegisterRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<ISharedRepository, SharedRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IBookTransactionRepository, BookTransactionTransactionRepository>();
        services.Configure<JWT>(configuration.GetSection("JWT"));
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
        TypeAdapterConfig<RegisterUser, User>
            .NewConfig()
            .Ignore(x => x.PasswordHash)
            .Ignore(x => x.PasswordSlot);
    }
}
