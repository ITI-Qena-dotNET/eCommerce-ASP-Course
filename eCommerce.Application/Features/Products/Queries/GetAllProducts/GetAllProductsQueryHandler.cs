using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Application.Features.Products.Queries.GetAllProducts;

public sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsDTO>>
{
    private readonly AppDbContext _context;

    public GetAllProductsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllProductsDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await _context.Products
            .Select(x => new { x.ID, x.Name, x.Description, x.Price })
            .ToListAsync(cancellationToken);

        var result = new List<GetAllProductsDTO>();

        foreach (var product in allProducts)
        {
            result.Add(new GetAllProductsDTO
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            });
        }

        return result;
    }
}
