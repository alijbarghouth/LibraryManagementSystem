using Domain.DTOs.PaginationsDTOs;

namespace Application.Query.BookQuery;

public record SearchByTitleQuery
{
    public string? BookTitle { get; set; }
    public PaginationQueries Queries { get; set; } = new PaginationQueries();
}
