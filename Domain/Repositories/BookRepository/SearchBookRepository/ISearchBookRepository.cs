using Domain.DTOs.BookDTOs;
using Domain.DTOs.PaginationsDTOs;

namespace Domain.Repositories.BookRepository.SearchBookRepository;

public interface ISearchBookRepository
{
    Task<List<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter);
    Task<List<Book>> SearchBookByAuhtorName(string authorName, PaginationFilter filter);
    Task<List<Book>> SearchBookByBookGenre(string bookGenre, PaginationFilter filter);
}
