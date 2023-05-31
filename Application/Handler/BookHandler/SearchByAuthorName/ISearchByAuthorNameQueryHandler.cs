using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;

namespace Application.Handler.BookHandler.SearchByAuthorName;

public interface ISearchByAuthorNameQueryHandler
{
    Task<PagedResponse<Book>> Handel(SearchByTAuthorNameQuery query);
}
