using Domain.DTOs.BookGenreDTOs;

namespace Application.Command.BookGenreCommand;

public record AddBookGenreCommand
(
    BookGenre BookGenre
);