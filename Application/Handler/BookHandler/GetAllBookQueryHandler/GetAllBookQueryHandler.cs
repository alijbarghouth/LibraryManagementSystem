using Application.Cashing;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.Response;
using Domain.Services.BookService.BookCruds;

namespace Application.Handler.BookHandler.GetAllBookQueryHandler;

public sealed class GetAllBookQueryHandler  : IGetAllBookQueryHandler
{
    private readonly IBookCrudsService _bookCrudsService;
    private readonly ICashService _cashService;
    public GetAllBookQueryHandler(IBookCrudsService bookCrudsService,
        ICashService cashService)
    {
        _bookCrudsService = bookCrudsService;
        _cashService = cashService;
    }

    public async Task<List<Response<Book>>> Handel()
    {
        return await _cashService.GetAsync<List<Response<Book>>>("Books", async () =>
        {
            var books = await _bookCrudsService.GetAllBook();
            return books;
        });
    }
}