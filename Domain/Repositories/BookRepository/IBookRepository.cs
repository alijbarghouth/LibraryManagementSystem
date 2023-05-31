using Domain.DTOs.BookAuthorDTOs;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;

namespace Domain.Repositories.BookRepository;

public interface IBookRepository
{
    Task<List<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter);
    Task<List<Book>> SearchBookByAuhtorName(string AuthorName, PaginationFilter filter);
}
