using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.BookDTOs;
using System.Globalization;

namespace Domain.DTOs.BookAuthorDTOs;

public record BookAuthor
    (
    string BookName,
    List<string> AuthorName
    );
