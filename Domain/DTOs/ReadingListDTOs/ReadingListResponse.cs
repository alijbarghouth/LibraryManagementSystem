using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.GenreDTOs;
using Domain.Shared.Enums;

namespace Domain.DTOs.ReadingListDTOs;

public record ReadingListResponse
(
    Guid UserId,
    Guid BookId,
    string BookName,
    List<Genre> Genres,
    List<Author> Authors,
    BookStatus BookStatus
);