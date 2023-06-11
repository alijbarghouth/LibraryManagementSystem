using Application.Cashing;
using Domain.DTOs.UserDTOs;
using Domain.Repositories.AuthorRepository;
using Domain.Repositories.BookAuthorRepository;
using Domain.Repositories.BookGenreRepository;
using Domain.Repositories.BookRecommendationRepository;
using Domain.Repositories.BookRepository.BookCrudsRepository;
using Domain.Repositories.BookRepository.SearchBookRepository;
using Domain.Repositories.BookReviewRepository;
using Domain.Repositories.BookTransactionRepository;
using Domain.Repositories.GenreRepository;
using Domain.Repositories.InteractionRepository;
using Domain.Repositories.ModerationRepository;
using Domain.Repositories.NotificationRepository;
using Domain.Repositories.PatronProfileRepository;
using Domain.Repositories.ReadingListRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Repositories.UserRepositories;
using Domain.Services.EmailService;
using Domain.Shared.Exceptions;
using Infrastructure.Cashing;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Infrastructure.Repositories.AuthorRepository;
using Infrastructure.Repositories.BookAuthorRepository;
using Infrastructure.Repositories.BookGenreRepository;
using Infrastructure.Repositories.BookRecommendationRepository;
using Infrastructure.Repositories.BookRepository.BookCrudsRepository;
using Infrastructure.Repositories.BookRepository.SearchBookRepository;
using Infrastructure.Repositories.BookReviewRepository;
using Infrastructure.Repositories.GenreRepository;
using Infrastructure.Repositories.BookTransactionRepository;
using Infrastructure.Repositories.InteractionRepository;
using Infrastructure.Repositories.ModerationRepository;
using Infrastructure.Repositories.NotificationRepository;
using Infrastructure.Repositories.PatronProfileRepository;
using Infrastructure.Repositories.ReadingListRepository;
using Infrastructure.Repositories.SharedRepositories;
using Infrastructure.Repositories.UserRepositories;
using Infrastructure.Settings;
using Infrastructure.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations;

public static class Configuration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        AddLibraryDbContext(services, configuration);
        AddRedisConfig(services, configuration);
        AddCustomDependencies(services, configuration);
        AddMapsterConfiguration();
        return services;
    }

    private static void AddCustomDependencies(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IRegisterRepository, RegisterRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<ISharedUserRepository, SharedUserRepository>();
        services.AddScoped<ISharedBookManagementRepository, SharedBookManagementRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<ISearchBookRepository, SearchBookRepository>();
        services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IBookTransactionRepository, BookTransactionTransactionRepository>();
        services.AddScoped<IPatronProfileRepository, PatronProfileRepository>();
        services.AddScoped<IBookCrudsRepository, BookCrudsRepository>();
        services.AddScoped<IBookGenreRepository, BookGenreRepository>();
        services.AddScoped<ICashService, CashService>();
        services.AddScoped<IReadingListRepository, ReadingListRepository>();
        services.AddScoped<IBookReviewRepository, BookReviewRepository>();
        services.AddScoped<IInteractionRepository, InteractionRepository>();
        services.AddScoped<IModerationRepository, ModerationRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IEmailService, EmailService.EmailService>();
        services.AddScoped<IBookRecommendationRepository, BookRecommendationRepository>();
        services.Configure<JWT>(configuration.GetSection(nameof(JWT)));
        services.Configure<Cash>(configuration.GetSection(nameof(Cash)));
    }

    private static void AddLibraryDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(delegate(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("LibraryDbContext"));
        });
    }

    private static void AddRedisConfig(IServiceCollection services, IConfiguration configuration)
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
        TypeAdapterConfig<UpdateLibrarianRequest, User>
            .NewConfig()
            .Ignore(x => x.PasswordHash)
            .Ignore(x => x.PasswordSlot);
    }
}