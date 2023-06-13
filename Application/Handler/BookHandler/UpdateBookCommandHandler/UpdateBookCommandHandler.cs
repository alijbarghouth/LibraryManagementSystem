using Application.Cashing;
using Application.Command.BookCommand;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.Response;
using Domain.Services.BookService.BookCruds;

namespace Application.Handler.BookHandler.UpdateBookCommandHandler;

public sealed class UpdateBookCommandHandler : IUpdateBookCommandHandler
{
    private readonly IBookCrudsService _bookCrudsService;
    private readonly ICashService _cashService;

    public UpdateBookCommandHandler(IBookCrudsService bookCrudsService,
        ICashService cashService)
    {
        _bookCrudsService = bookCrudsService;
        _cashService = cashService;
    }

    public async Task<Response<BookRequest>> Handel(UpdateBookCommand command)
    {
        var book = await _bookCrudsService.UpdateBook(command.BookId, command.Book);
        await _cashService.RemoveAsync("Book");
        return book;
    }
}