namespace Domain.Repositories.CrudsRepository;

public interface ICrudsRepository <TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task SaveChangesAsync();
}