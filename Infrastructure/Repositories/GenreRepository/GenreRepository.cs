using Domain.Repositories.GenreRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.GenreRepository;

public sealed class GenreRepository : IGenreRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public GenreRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Domain.DTOs.GenreDTOs.Genre> AddBookGenre(Domain.DTOs.GenreDTOs.Genre genre)
    {
        await _libraryDbContext.Genres.AddAsync(genre.Adapt<Genre>());
        return genre;
    }

    public async Task<bool> IsBookGenreExists(string bookGenre)
    {
        return await _libraryDbContext.Genres
            .AsNoTracking()
            .AnyAsync(x => x.Name == bookGenre);
    }

    public async Task<bool> IsBookGenreExistsById(Guid genreId)
    {
        return await _libraryDbContext.Genres
            .AsNoTracking()
            .AnyAsync(x => x.Id == genreId);
    }
}