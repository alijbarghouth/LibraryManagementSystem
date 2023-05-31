using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;

namespace Application.Handler.BookHandler.SearchByTitle;

public interface ISearchByTitleQueryHandler
{
    Task<PagedResponse<Book>> Handel(SearchByTitleQuery query);
}
