using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Infrastructure.Data;
using MediatR;

namespace eCommerce.Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductDTO>
{
    private readonly AppDbContext _context;

    public UpdateProductCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateProductDTO?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(new object[] { request.dto.ID }, cancellationToken);

        if (product is null)
        {
            return null;
        }

        product.Name = request.dto.Name;
        product.Description = request.dto.Description;
        product.Price = request.dto.Price;

        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            ID = product.ID,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
        };
    }
}
