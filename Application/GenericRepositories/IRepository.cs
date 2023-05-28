namespace Application.GenericRepositories;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(int id);
    IQueryable<TEntity> GetQueryable();
    Task<TEntity> Insert(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    Task SaveChangesAsync();
}
