using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Domain.Contracts;
using Mediator;

namespace eCommerce.Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetAllProductsDTO>
{
    private readonly IProductRepository _repository;

    public GetProductByIdQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<GetAllProductsDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.ID, cancellationToken);

        return new()
        {
            ID = product.ID,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
        };
    }
}
