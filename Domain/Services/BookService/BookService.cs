using Domain.DTOs.BookDTOs;
using Domain.Repositories.BookRepository;

namespace Domain.Services.BookService;

public sealed class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<PagedResponse<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter)
    {
        var query = await _bookRepository.SearchBookByTitle(bookTitle, filter);

        var paginationResponse = new PagedResponse<Book>(query)
        {
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber
        };
        paginationResponse.NextPage = $"/api/Order/GetAllOrdersByfilter?PageNumber={paginationResponse.PageNumber + 1}&PageSize={paginationResponse.PageSize}";
        paginationResponse.PreviousPage = paginationResponse.PageNumber > 1 ? $"/api/Order/GetAllOrdersByfilter?PageNumber={paginationResponse.PageNumber - 1}&PageSize={paginationResponse.PageSize}" : null;


        return paginationResponse;
    }
}
