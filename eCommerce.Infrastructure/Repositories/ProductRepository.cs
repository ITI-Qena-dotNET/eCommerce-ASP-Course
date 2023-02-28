using eCommerce.Domain.Contracts;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public sealed class ProductRepository : GenericRepository<Product, Guid>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken ct = default)
        => await _db.Where(x => x.ID == id).ExecuteDeleteAsync(ct);
}
