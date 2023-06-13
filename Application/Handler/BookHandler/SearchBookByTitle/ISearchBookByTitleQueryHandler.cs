using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;

namespace Application.Handler.BookHandler.SearchBookByTitle;

public interface ISearchBookByTitleQueryHandler
{
    Task<PagedResponse<Book>> Handel(SearchBookByTitleQuery query);
}
