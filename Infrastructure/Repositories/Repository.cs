using Application.GenericRepositories;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly LibraryDBContext _dbContext;

    public Repository(LibraryDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<TEntity>> GetAll()
    {
        return await _dbContext.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TEntity?> GetById(int id)
    {
        return await _dbContext.Set<TEntity>()
             .FindAsync(id);
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
        await _dbContext.Set<TEntity>()
            .AddAsync(entity);
        return entity;
    }
    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>()
            .Remove(entity);
    }
    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>()
            .Update(entity);
    }
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
