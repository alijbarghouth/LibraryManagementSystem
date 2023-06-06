using Application.Command.AuthorCommand;
using Application.Command.BookAuthorCommand;
using Application.Command.BookGenreCommand;
using Application.Command.BookTransactionCommand;
using Application.Command.GenreCommand;
using Application.Command.PatronProfileCommand;
using Application.Command.ReadingListCommand;
using Application.Command.UserCommand;
using Application.Handler.AuthorHandler.AddAuthorCommandHandler;
using Application.Handler.AuthorHandler.DeleteAuthorCommandHandler;
using Application.Handler.AuthorHandler.UpdateAuthorCommandHandler;
using Application.Handler.BookAuthorHandler;
using Application.Handler.BookGenreHandler.AddBookGenreCommandHandler;
using Application.Handler.BookHandler.AddBookCommandHandler;
using Application.Handler.BookHandler.DeleteBookCommandHandler;
using Application.Handler.BookHandler.GetAllBookQueryHandler;
using Application.Handler.BookHandler.SearchBookByAuthorName;
using Application.Handler.BookHandler.SearchBookByGenre;
using Application.Handler.BookHandler.SearchBookByTitle;
using Application.Handler.BookHandler.UpdateBookCommandHandler;
using Application.Handler.BookTransactionHandler.AcceptReturnedBook;
using Application.Handler.BookTransactionHandler.CheckOutBook;
using Application.Handler.BookTransactionHandler.GetOverdueBooks;
using Application.Handler.BookTransactionHandler.ReserveBook;
using Application.Handler.GenreHandler;
using Application.Handler.PatronProfileHandler.GetPatronProfileQueryHandler;
using Application.Handler.PatronProfileHandler.ViewAndEditPatronProfileCommandHandler;
using Application.Handler.ReadingListHandler.AddReadingListHandler;
using Application.Handler.ReadingListHandler.DeleteReadingListHandler;
using Application.Handler.ReadingListHandler.GetAllReadingListQueryHandler;
using Application.Handler.ReadingListHandler.UpdateReadingListHandler;
using Application.Handler.UserHandler.DeleteLibrarianHandler;
using Application.Handler.UserHandler.LoginHandler;
using Application.Handler.UserHandler.RefreshTokenHandler;
using Application.Handler.UserHandler.RegisterHandler;
using Application.Handler.UserHandler.RoleHandler;
using Application.Handler.UserHandler.UpdateLibrarianHandler;
using Application.Query.PatronProfile;
using Application.Validator.AuthorBookValidator;
using Application.Validator.BookGenreValidator;
using Application.Validator.BookTransactionValidator;
using Application.Validator.GenreValidator;
using Application.Validator.PatronProfileValidator;
using Application.Validator.ReadingListValidator;
using Application.Validator.UserValidator;
using Domain.Services.AuthorService;
using Domain.Services.BookAuthorService;
using Domain.Services.BookGenreService;
using Domain.Services.BookService.BookCruds;
using Domain.Services.BookService.BookSearch;
using Domain.Services.BookTransactionService;
using Domain.Services.GenreService;
using Domain.Services.PatronProfile;
using Domain.Services.ReadingListService;
using Domain.Services.UserService.AuthService;
using Domain.Services.UserService.LoginService;
using Domain.Services.UserService.RegisterService;
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
        services.AddScoped<IValidator<AddGenreCommand>, AddGenreCommandValidation>();
        services.AddScoped<IValidator<AcceptReturnedBookCommand>, AcceptReturnedBookCommandValidation>();
        services.AddScoped<IValidator<CheckOutBookCommand>, CheckOutBookCommandValidation>();
        services.AddScoped<IValidator<ReserveBookCommand>, ReserveBookCommandValidation>();
        services.AddScoped<IValidator<ViewAndEditPatronProfileCommand>, ViewAndEditPatronProfileCommandValidation>();
        services.AddScoped<IValidator<PatronProfileQuery>, PatronProfileQueryValidation>();
        services.AddScoped<IValidator<AddBookGenreCommand>, AddBookGenreCommandValidation>();
        services.AddScoped<IValidator<AddReadingListCommand>, AddReadingListCommandValidation>();
        services.AddScoped<IValidator<UpdateReadingListCommand>, UpdateReadingListCommandValidation>();
        services.AddScoped<IValidator<DeleteReadingListCommand>, DeleteReadingListCommandValidation>();
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
        services.AddScoped<IBookSearchService, BookSearchService>();
        services.AddScoped<IBookAuthorService, BookAuthorService>();
        services.AddScoped<IBookAuthorCommandHandler, BookAuthorCommandHandler>();
        services.AddScoped<ISearchBookByGenreQueryHandler, SearchBookByGenreQueryHandler>();
        services.AddScoped<IAddGenreCommandHandler, AddGenreCommandHandler>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IBookTransactionService, BookTransactionService>();
        services.AddScoped<IReserveBookCommandHandler, ReserveBookCommandHandler>();
        services.AddScoped<IAddBookCommandHandler, AddBookCommandHandler>();
        services.AddScoped<ICheckOutBookCommandHandler, CheckOutBookCommandHandler>();
        services.AddScoped<IGetOverdueBooksQueryHandler, GetOverdueBooksQueryHandler>();
        services.AddScoped<IAcceptReturnedBookCommandHandler, AcceptReturnedBookCommandHandler>();
        services.AddScoped<IGetPatronProfileQueryHandler, GetPatronProfileQueryHandler>();
        services.AddScoped<IPatronProfileService, PatronProfileService>();
        services.AddScoped<IViewAndEditPatronProfileCommandHandler, ViewAndEditPatronProfileCommandHandler>();
        services.AddScoped<IBookCrudsService, BookCrudsService>();
        services.AddScoped<IUpdateBookCommandHandler, UpdateBookCommandHandler>();
        services.AddScoped<IDeleteBookCommandHandler, DeleteBookCommandHandler>();
        services.AddScoped<IGetAllBookQueryHandler, GetAllBookQueryHandler>();
        services.AddScoped<IAuthorCrudsService, AuthorCrudsService>();
        services.AddScoped<IDeleteAuthorCommandHandler, DeleteAuthorCommandHandler>();
        services.AddScoped<IUpdateAuthorCommandHandler, UpdateAuthorCommandHandler>();
        services.AddScoped<IAddAuthorCommandHandler, AddAuthorCommandHandler>();
        services.AddScoped<IUpdateLibrarianRequestCommandHandler, UpdateLibrarianRequestCommandHandler>();
        services.AddScoped<IDeleteLibrarianRequestCommandHandler, DeleteLibrarianRequestCommandHandler>();
        services.AddScoped<IBookGenreService, BookGenreService>();
        services.AddScoped<IAddBookGenreCommandHandler, AddBookGenreCommandHandler>();
        services.AddScoped<IReadingListService, ReadingListService>();
        services.AddScoped<IAddReadingListCommandHandler, AddReadingListCommandHandler>();
        services.AddScoped<IUpdateReadingListCommandHandler, UpdateReadingListCommandHandler>();
        services.AddScoped<IDeleteReadingListCommandHandler, DeleteReadingListCommandHandler>();
        services.AddScoped<IGetAllReadingListQueryHandler, GetAllReadingListQueryHandler>();
    }
}