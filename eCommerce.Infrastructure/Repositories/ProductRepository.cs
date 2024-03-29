﻿using eCommerce.Domain.Contracts;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Data;
using eCommerce.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public sealed class ProductRepository : GenericRepository<Product, Guid>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken ct = default)
        => await _db.Where(x => x.ID == id).ExecuteDeleteAsync(ct);

    public async Task<IEnumerable<Product>> FilterAsync(string? filter = null, CancellationToken ct = default)
    {
        return await _db
            .WhereIf(!string.IsNullOrEmpty(filter), p => p.Name.Contains(filter!) || p.Description.Contains(filter!))
            //.WhereIf(!string.IsNullOrEmpty(filter), p => p.Description.Contains(filter!))
            .ToListAsync(ct);
    }
}
