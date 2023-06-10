using Domain.DTOs.PaginationsDTOs;

namespace Application.Query.BookQuery;

public record  SearchBookByGenerQuery
{
    public string? BookGenre { get; set; }
    public PaginationQueries Queries { get; set; } = new PaginationQueries();
}
