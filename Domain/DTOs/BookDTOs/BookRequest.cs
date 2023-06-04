using Domain.Shared.Enums;

namespace Domain.DTOs.BookDTOs;

public record BookRequest
(
    string Title,
    DateTime PublicationDate,
    BookStatus BookStatus,
    int Count
);