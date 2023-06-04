using Domain.DTOs.BookDTOs;
using Domain.Services.BookService.BookCruds;

namespace Application.Handler.BookHandler.GetAllBookQueryHandler;

public sealed class GetAllBookQueryHandler  : IGetAllBookQueryHandler
{
    private readonly IBookCrudsService _bookCrudsService;

    public GetAllBookQueryHandler(IBookCrudsService bookCrudsService)
    {
        _bookCrudsService = bookCrudsService;
    }

    public async Task<List<Book>> Handel()
    {
        return await _bookCrudsService.GetAllBook();
    }
}