using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.GenreDTOs;

namespace Domain.DTOs.BookRecommendationDTOs;

public record BookRecommendation
(
    string BookTitle,
    List<Genre> Genres,
    List<Author> Authors
);