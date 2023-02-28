using eCommerce.Domain.Contracts;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public abstract class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
{
    private readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _db;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _db = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default)
        => await _db.ToListAsync(ct);

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct = default)
        => await _db.FindAsync(new object[] { id! }, ct);

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default)
    {
        await _db.AddAsync(entity, ct);
        return entity;
    }

    public bool Update(TEntity entity)
    {
        _db.Update(entity);
        return true;
    }

    public bool DeleteAsync(TEntity entity)
    {
        _db.Remove(entity);
        return true;
    }

    public async Task<int> CompleteWork(CancellationToken ct = default)
        => await _context.SaveChangesAsync(ct);
}
