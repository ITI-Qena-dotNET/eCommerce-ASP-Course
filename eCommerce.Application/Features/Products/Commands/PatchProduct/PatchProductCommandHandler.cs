using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Domain.Contracts;
using Mediator;

namespace eCommerce.Application.Features.Products.Commands.PatchProduct;

public sealed class PatchProductCommandHandler : IRequestHandler<PatchProductCommand, GetAllProductsDTO>
{
    private readonly IProductRepository _repository;

    public PatchProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<GetAllProductsDTO?> Handle(PatchProductCommand request, CancellationToken ct)
    {
        var product = await _repository.GetByIdAsync(request.ID, ct);

        if (product is null)
            return null;

        request.PatchUpdates.ApplyTo(product);
        _repository.Update(product);
        await _repository.CompleteWork(ct);

        return new()
        {
            ID = product.ID,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}
