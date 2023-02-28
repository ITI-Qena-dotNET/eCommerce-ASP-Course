using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Domain.Contracts;
using Mediator;

namespace eCommerce.Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductDTO>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<UpdateProductDTO?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.dto.ID, cancellationToken);

        if (product is null)
        {
            return null;
        }

        product.Name = request.dto.Name;
        product.Description = request.dto.Description;
        product.Price = request.dto.Price;

        _repository.Update(product);
        await _repository.CompleteWork(cancellationToken);

        return new()
        {
            ID = product.ID,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
        };
    }
}
