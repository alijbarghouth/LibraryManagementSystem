using Domain.DTOs.BookDTOs;
using Domain.Repositories.BookRepository;

namespace Domain.Services.BookService;

public sealed class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly static string BaseUrl = "/api/Order/GetAllOrdersByfilter";
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<PagedResponse<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter)
    {
        var query = await _bookRepository.SearchBookByTitle(bookTitle, filter);

        return GetPagedResponse(query, filter);
    }
    public async Task<PagedResponse<Book>> SearchBookByAuthor(string authorName, PaginationFilter filter)
    {
        var query = await _bookRepository.SearchBookByAuhtorName(authorName, filter);

        return GetPagedResponse(query, filter);
    }
    private static PagedResponse<Book> GetPagedResponse(List<Book> query, PaginationFilter filter)
    {
        var paginationResponse = new PagedResponse<Book>(query)
        {
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber
        };
        paginationResponse.NextPage = $"{BaseUrl}?PageNumber={paginationResponse.PageNumber + 1}&PageSize={paginationResponse.PageSize}";
        paginationResponse.PreviousPage = paginationResponse.PageNumber > 1 
            ? $"{BaseUrl}?PageNumber={paginationResponse.PageNumber - 1}&PageSize={paginationResponse.PageSize}" 
            : null;

        return paginationResponse;
    }
}
