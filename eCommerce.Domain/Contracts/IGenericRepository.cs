namespace eCommerce.Domain.Contracts;

public interface IGenericRepository<TEntity, TId> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default);
    bool DeleteAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct = default);
    bool Update(TEntity entity);
    Task<int> CompleteWork(CancellationToken ct = default);
}