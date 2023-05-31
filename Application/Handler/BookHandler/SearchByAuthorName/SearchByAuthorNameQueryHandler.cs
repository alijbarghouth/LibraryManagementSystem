using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.Services.BookService;
using Mapster;

namespace Application.Handler.BookHandler.SearchByAuthorName;

public sealed class SearchByAuthorNameQueryHandler : ISearchByAuthorNameQueryHandler
{
    private readonly IBookService _bookService;

    public SearchByAuthorNameQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }
    public async Task<PagedResponse<Book>> Handel(SearchByTAuthorNameQuery query)
    {
        var filter = query.Queries.Adapt<PaginationFilter>();
        return await _bookService.SearchBookByAuthor(query.AuthorName, filter);
    }
}
