using Application.Cashing;
using Application.Command.BookCommand;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.Response;
using Domain.Services.BookService.BookCruds;

namespace Application.Handler.BookHandler.AddBookCommandHandler;

public sealed class AddBookCommandHandler : IAddBookCommandHandler
{
    private readonly IBookCrudsService _bookCrudsService;
    private readonly ICashService _cashService;
    public AddBookCommandHandler(IBookCrudsService bookCrudsService,
        ICashService cashService)
    {
        _bookCrudsService = bookCrudsService;
        _cashService = cashService;
    }

    public async Task<Response<BookRequest>> Handel(AddBookCommand command)
    {
        var book = await _bookCrudsService.AddBook(command.Book);
        await _cashService.RemoveAsync("Book");
        return book;
    }
}