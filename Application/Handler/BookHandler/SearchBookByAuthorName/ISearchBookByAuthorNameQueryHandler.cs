using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;

namespace Application.Handler.BookHandler.SearchBookByAuthorName;

public interface ISearchBookByAuthorNameQueryHandler
{
    Task<PagedResponse<Book>> Handel(SearchBookByAuthorNameQuery query);
}
