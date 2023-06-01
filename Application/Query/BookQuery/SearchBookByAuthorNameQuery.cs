using Domain.DTOs.PaginationsDTOs;

namespace Application.Query.BookQuery;

public record SearchBookByAuthorNameQuery
{
    public string? AuthorName { get; set; }
    public PaginationQueries Queries { get; set; } = new PaginationQueries();
}
