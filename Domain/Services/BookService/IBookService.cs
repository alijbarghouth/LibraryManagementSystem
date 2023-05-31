using Domain.DTOs.BookDTOs;

namespace Domain.Services.BookService;

public interface IBookService
{
    Task<PagedResponse<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter);
}
