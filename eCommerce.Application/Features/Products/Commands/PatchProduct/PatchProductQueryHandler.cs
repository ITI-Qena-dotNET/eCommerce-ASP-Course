using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Infrastructure.Data;
using MediatR;

namespace eCommerce.Application.Features.Products.Commands.PatchProduct;

public sealed class PatchProductQueryHandler : IRequestHandler<PatchProductQuery, GetAllProductsDTO>
{
    private readonly AppDbContext _context;

    public PatchProductQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetAllProductsDTO?> Handle(PatchProductQuery request, CancellationToken ct)
    {
        var product = await _context.Products.FindAsync(new object[] { request.ID }, ct);

        if (product is null)
            return null;

        request.PatchUpdates.ApplyTo(product);
        _context.Products.Update(product);
        await _context.SaveChangesAsync(ct);

        return new()
        {
            ID = product.ID,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}
