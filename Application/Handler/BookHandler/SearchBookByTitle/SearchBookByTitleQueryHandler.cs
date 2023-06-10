using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;
using Domain.Services.BookService;
using Domain.Services.BookService.BookSearch;
using Domain.Shared.Exceptions.CustomException;
using Mapster;

namespace Application.Handler.BookHandler.SearchBookByTitle;

public sealed class SearchBookByTitleQueryHandler : ISearchBookByTitleQueryHandler
{
    private readonly IBookSearchService _bookSearchService;

    public SearchBookByTitleQueryHandler(IBookSearchService bookSearchService)
    {
        _bookSearchService = bookSearchService;
    }

    public async Task<PagedResponse<Book>> Handel(SearchBookByTitleQuery query)
    {
        if (query.Queries.PageNumber < 1)
            throw new NoContentException("no content");

        var filter = query.Queries.Adapt<PaginationFilter>();
        return await _bookSearchService.SearchBookByTitle(query.BookTitle,filter);
    }
}
