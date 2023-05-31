using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.BookDTOs;

namespace Domain.DTOs.BookAuthorDTOs;

public record BookAuthor
    (
    string BookName,
    List<Author> Authors
    );
