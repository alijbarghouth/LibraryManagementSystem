using Domain.DTOs.BookDTOs;

namespace Domain.Repositories.BookRepository;

public interface IBookRepository
{
    Task<List<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter);
}
