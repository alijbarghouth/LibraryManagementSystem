using Domain.Repositories.GenreRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.GenreRepository;

public sealed class GenreRepository : IGenreRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public GenreRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Domain.DTOs.GenreDTOs.Genre> AddBookGenre(Domain.DTOs.GenreDTOs.Genre genre)
    {
        await _libraryDbContext.Genres.AddAsync(genre.Adapt<Genre>());
        return genre;
    }
}