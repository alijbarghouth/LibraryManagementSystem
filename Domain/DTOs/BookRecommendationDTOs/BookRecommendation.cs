using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.GenreDTOs;

namespace Domain.DTOs.BookRecommendationDTOs;

public record BookRecommendation
(
    string BookTitle,
    double AverageRating,
    List<Genre> Genres,
    List<Author> Authors
);