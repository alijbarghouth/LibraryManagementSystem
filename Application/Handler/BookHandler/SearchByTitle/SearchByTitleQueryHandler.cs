using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;
using Domain.Services.BookService;
using Mapster;

namespace Application.Handler.BookHandler.SearchByTitle;

public sealed class SearchByTitleQueryHandler : ISearchByTitleQueryHandler
{
    private readonly IBookService _bookService;

    public SearchByTitleQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<PagedResponse<Book>> Handel(SearchByTitleQuery query)
    {
        var filter = query.Queries.Adapt<PaginationFilter>();
        return await _bookService.SearchBookByTitle(query.BookTitle,filter);
    }
}
