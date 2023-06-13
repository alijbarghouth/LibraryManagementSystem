using Application.Query.BookQuery;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;

namespace Application.Handler.BookHandler.SearchBookByGenre;

public interface ISearchBookByGenreQueryHandler
{
    Task<PagedResponse<Book>> Handel(SearchBookByGenerQuery query);
}
