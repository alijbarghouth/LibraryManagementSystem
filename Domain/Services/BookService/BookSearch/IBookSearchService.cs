using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;

namespace Domain.Services.BookService.BookSearch;

public interface IBookSearchService
{
    Task<PagedResponse<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter);
    Task<PagedResponse<Book>> SearchBookByAuthor(string auhtorName, PaginationFilter filter);
    Task<PagedResponse<Book>> SearchBookByBookGenre(string bookGenre, PaginationFilter filter);
}
