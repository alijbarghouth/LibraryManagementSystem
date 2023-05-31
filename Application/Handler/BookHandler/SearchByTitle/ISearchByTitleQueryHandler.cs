using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;

namespace Application.Handler.BookHandler.SearchByTitle;

public interface ISearchByTitleQueryHandler
{
    Task<PagedResponse<Book>> Handel(SearchByTitleQuery query);
}
