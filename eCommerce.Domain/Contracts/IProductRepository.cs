﻿using eCommerce.Domain.Entities;

namespace eCommerce.Domain.Contracts;

public interface IProductRepository : IGenericRepository<Product, Guid>
{
    Task<int> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Product>> FilterAsync(string? filter = null, CancellationToken ct = default);
}