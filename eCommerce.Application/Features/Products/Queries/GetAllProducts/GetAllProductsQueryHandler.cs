using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Domain.Contracts;
using Mediator;

namespace eCommerce.Application.Features.Products.Queries.GetAllProducts;

public sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsDTO>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<List<GetAllProductsDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await _repository.GetAllAsync(cancellationToken);

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
