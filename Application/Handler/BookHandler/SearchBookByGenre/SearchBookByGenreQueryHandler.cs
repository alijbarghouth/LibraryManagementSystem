using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;
using Domain.Services.BookService;
using Domain.Services.BookService.BookSearch;
using Domain.Shared.Exceptions.CustomException;
using Mapster;

namespace Application.Handler.BookHandler.SearchBookByGenre;

public sealed class SearchBookByGenreQueryHandler : ISearchBookByGenreQueryHandler
{
    private readonly IBookSearchService _bookSearchService;

    public SearchBookByGenreQueryHandler(IBookSearchService bookSearchService)
    {
        _bookSearchService = bookSearchService;
    }

    public async Task<PagedResponse<Book>> Handel(SearchBookByGenerQuery query)
    {
        if (query.Queries.PageNumber < 1)
            throw new NoContentException("no content");

        var filter = query.Queries.Adapt<PaginationFilter>();
        return await _bookSearchService.SearchBookByBookGenre(query.BookGenre, filter);
    }
}
