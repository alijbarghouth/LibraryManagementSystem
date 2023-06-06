using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.GenreDTOs;
using Domain.Shared.Enums;

namespace Domain.DTOs.BookDTOs;

public record Book
(
    string Title,
    List<Author> Authors,
    DateTime PublicationDate,
    List<Genre> Genre,
    BookStatus BookStatus,
    int Count
);