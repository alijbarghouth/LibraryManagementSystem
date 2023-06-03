using Application.Command.BookCommand;
using Domain.DTOs.BookDTOs;
using Domain.Services.BookService.BookCruds;

namespace Application.Handler.BookHandler.UpdateBookCommandHandler;

public class UpdateBookCommandHandler : IUpdateBookCommandHandler
{
    private readonly IBookCrudsService _bookCrudsService;

    public UpdateBookCommandHandler(IBookCrudsService bookCrudsService)
    {
        _bookCrudsService = bookCrudsService;
    }

    public async Task<BookRequest> Handel(UpdateBookCommand command)
    {
        return await _bookCrudsService.UpdateBook(command.BookId, command.Book);
    }
}