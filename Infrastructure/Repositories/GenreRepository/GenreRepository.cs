using Domain.Repositories.GenreRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.GenreRepository;

public sealed class GenreRepository : IGenreRepository
{
    private readonly LibraryDBContext _libraryDBContext;

    public GenreRepository(LibraryDBContext libraryDBContext)
    {
        _libraryDBContext = libraryDBContext;
    }

    public async Task<Domain.DTOs.GenreDTOs.Genre> AddBookGenre(Domain.DTOs.GenreDTOs.Genre genre)
    {
        await _libraryDBContext.Genres.AddAsync(genre.Adapt<Genre>());
        return genre;
    }

    public async Task<bool> IsBookGenreExists(string bookGenre)
    {
        return await _libraryDBContext.Genres
            .AsNoTracking()
            .AnyAsync(x => x.Name == bookGenre);
    }

    public async Task<bool> IsBookGenreExistsById(Guid genreId)
    {
        return await _libraryDBContext.Genres
            .AsNoTracking()
            .AnyAsync(x => x.Id == genreId);
    }
}