using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;

namespace Application.Handler.BookHandler.SearchByAuthorName;

public interface ISearchByAuthorNameQueryHandler
{
    Task<PagedResponse<Book>> Handel(SearchByTAuthorNameQuery query);
}
