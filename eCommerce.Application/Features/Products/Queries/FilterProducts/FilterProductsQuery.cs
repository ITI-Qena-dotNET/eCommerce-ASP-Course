using eCommerce.Application.Features.Products.DTOs;
using Mediator;

namespace eCommerce.Application.Features.Products.Queries.GetAllProducts;

public sealed class FilterProductsQuery : IRequest<List<GetAllProductsDTO>>
{
    public required string Filter { get; set; }
}
