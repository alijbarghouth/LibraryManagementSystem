using Domain.DTOs.BookDTOs;

namespace Application.Command.BookCommand;

public record AddBookCommand
(
    BookRequest Book
);