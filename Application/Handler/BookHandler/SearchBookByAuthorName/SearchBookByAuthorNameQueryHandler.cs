using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;
using Domain.Services.BookService;
using Domain.Shared.Exceptions.CustomException;
using Mapster;

namespace Application.Handler.BookHandler.SearchBookByAuthorName;

public sealed class SearchBookByAuthorNameQueryHandler : ISearchBookByAuthorNameQueryHandler
{
    private readonly IBookService _bookService;

    public SearchBookByAuthorNameQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }
    public async Task<PagedResponse<Book>> Handel(SearchBookByAuthorNameQuery query)
    {
        if (query.Queries.PageNumber < 1)
            throw new NoContentException("no content");

        var filter = query.Queries.Adapt<PaginationFilter>();
        return await _bookService.SearchBookByAuthor(query.AuthorName, filter);
    }
}
