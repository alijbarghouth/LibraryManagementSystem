using Domain.DTOs.BookDTOs;

namespace Application.Command.BookCommand;

public record UpdateBookCommand
(
    Guid BookId, BookRequest Book
);