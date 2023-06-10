namespace Domain.DTOs.BookGenreDTOs;

public record BookGenre
(
    string BookName,
    List<string> Genre
);