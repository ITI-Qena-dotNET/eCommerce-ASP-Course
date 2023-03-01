using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Domain.Contracts;
using Mediator;

namespace eCommerce.Application.Features.Products.Queries.GetAllProducts;

public sealed class FilterProductsQueryHandler : IRequestHandler<FilterProductsQuery, List<GetAllProductsDTO>>
{
    private readonly IProductRepository _repository;

    public FilterProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<List<GetAllProductsDTO>> Handle(FilterProductsQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await _repository.FilterAsync(request.Filter, cancellationToken);

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
