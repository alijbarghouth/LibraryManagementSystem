using Application.Command.BookCommand;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.Response;
using Domain.Repositories.BookRepository.BookCrudsRepository;
using Domain.Services.BookService.BookCruds;

namespace Application.Handler.BookHandler.AddBookCommandHandler;

public sealed class AddBookCommandHandler : IAddBookCommandHandler
{
    private readonly IBookCrudsService _bookCrudsService;

    public AddBookCommandHandler(IBookCrudsService bookCrudsService)
    {
        _bookCrudsService = bookCrudsService;
    }

    public async Task<Response<BookRequest>> Handel(AddBookCommand command)
    {
        return await _bookCrudsService.AddBook(command.Book);
    }
}