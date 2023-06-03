using Domain.Repositories.CrudsRepository;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CrudsRepository;

public class CrudsRepository<TEntity> : ICrudsRepository<TEntity>
where TEntity : class 
{
    private readonly LibraryDBContext _libraryDbContext;

    public CrudsRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _libraryDbContext.Set<TEntity>()
            .ToListAsync();
    }

    public async void Insert(TEntity entity)
    {
        await _libraryDbContext.Set<TEntity>()
            .AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _libraryDbContext.Set<TEntity>()
            .Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _libraryDbContext.Set<TEntity>()
            .Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _libraryDbContext.SaveChangesAsync();
    }
}