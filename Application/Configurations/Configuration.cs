using Application.Command.AuthorCommand;
using Application.Command.BookAuthorCommand;
using Application.Command.BookTransactionCommand;
using Application.Command.GenreCommand;
using Application.Command.UserCommand;
using Application.Handler.AuthorHandler;
using Application.Handler.BookAuthorHandler;
using Application.Handler.BookHandler.AddBookCommandHandler;
using Application.Handler.BookHandler.SearchBookByAuthorName;
using Application.Handler.BookHandler.SearchBookByGenre;
using Application.Handler.BookHandler.SearchBookByTitle;
using Application.Handler.BookTransactionHandler.AcceptReturnedBook;
using Application.Handler.BookTransactionHandler.CheckOutBook;
using Application.Handler.BookTransactionHandler.GetOverdueBooks;
using Application.Handler.BookTransactionHandler.ReserveBook;
using Application.Handler.GenreHandler;
using Application.Handler.UserHandler.LoginHandler;
using Application.Handler.UserHandler.RefreshTokenHandler;
using Application.Handler.UserHandler.RegisterHandler;
using Application.Handler.UserHandler.RoleHandler;
using Application.Validator.AuthorBookValidator;
using Application.Validator.GenreValidator;
using Application.Validator.UserValidator;
using Domain.Services.AuthorService;
using Domain.Services.BookAuthorService;
using Domain.Services.BookService;
using Domain.Services.BookTransactionService;
using Domain.Services.GenreService;
using Domain.Services.Services.AuthService;
using Domain.Services.Services.LoginService;
using Domain.Services.Services.RegisterService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations;

public static class Configuration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        AddFluentValidation(services);
        AddCustomDependencies(services);
        return services;
    }

    private static void AddFluentValidation(IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddScoped<IValidator<RegisterUserCommand>, UserValidation>();
        services.AddScoped<IValidator<LoginUserCommand>, LoginRequestValidation>();
        services.AddScoped<IValidator<AddAuthorCommand>, AuthorValidation>();
        services.AddScoped<IValidator<AddBookAuthorCommand>, BookAuthorValidation>();
        services.AddScoped<IValidator<AddBookGenreCommand>, AddBookGenreCommandValidation>();
    }

    private static void AddCustomDependencies(IServiceCollection services)
    {
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRegisterUserCommandHandler, RegisterUserCommandHandler>();
        services.AddScoped<ILoginUserCommandHandler, LoginUserCommandHandler>();
        services.AddScoped<IRoleCommandHandler, RoleCommandHandler>();
        services.AddScoped<IRefreshTokenQueryHandler, RefreshTokenQueryHandler>();
        services.AddScoped<ISearchBookByTitleQueryHandler, SearchBookByTitleQueryHandler>();
        services.AddScoped<ISearchBookByAuthorNameQueryHandler, SearchBookByAuthorNameQueryHandler>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookAuthorService, BookAuthorService>();
        services.AddScoped<IBookAuthorCommandHandler, BookAuthorCommandHandler>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IAddAuthorCommandHandler, AddAuthorCommandHandler>();
        services.AddScoped<ISearchBookByGenreQueryHandler, SearchBookByGenreQueryHandler>();
        services.AddScoped<IAddBookGenreCommandHandler, AddBookGenreCommandHandler>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IBookTransactionService, BookTransactionService>();
        services.AddScoped<IReserveBookCommandHandler, ReserveBookCommandHandler>();
        services.AddScoped<IAddBookCommandHandler, AddBookCommandHandler>();
        services.AddScoped<ICheckOutBookCommandHandler, CheckOutBookCommandHandler>();
        services.AddScoped<IGetOverdueBooksQueryHandler, GetOverdueBooksQueryHandler>();
        services.AddScoped<IAcceptReturnedBookCommandHandler, AcceptReturnedBookCommandHandler>();
    }
}