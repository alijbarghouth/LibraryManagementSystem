using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;
using Domain.Services.BookService;
using Domain.Shared.Exceptions.CustomException;
using Mapster;

namespace Application.Handler.BookHandler.SearchBookByTitle;

public sealed class SearchBookByTitleQueryHandler : ISearchBookByTitleQueryHandler
{
    private readonly IBookService _bookService;

    public SearchBookByTitleQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<PagedResponse<Book>> Handel(SearchBookByTitleQuery query)
    {
        if (query.Queries.PageNumber < 1)
            throw new NoContentException("no content");

        var filter = query.Queries.Adapt<PaginationFilter>();
        return await _bookService.SearchBookByTitle(query.BookTitle,filter);
    }
}
