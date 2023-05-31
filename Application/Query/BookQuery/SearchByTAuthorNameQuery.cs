using Domain.DTOs.BookDTOs;

namespace Application.Query.BookQuery;

public record SearchByTAuthorNameQuery
{
    public string? AuthorName { get; set; }
    public PaginationQueries Queries { get; set; } = new PaginationQueries();
}
