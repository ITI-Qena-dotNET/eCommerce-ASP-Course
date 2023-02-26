using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Infrastructure.Data;
using MediatR;

namespace eCommerce.Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetAllProductsDTO>
{
    private readonly AppDbContext _context;

    public GetProductByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetAllProductsDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(new object[] { request.ID }, cancellationToken);

        return new()
        {
            ID = product.ID,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
        };
    }
}
