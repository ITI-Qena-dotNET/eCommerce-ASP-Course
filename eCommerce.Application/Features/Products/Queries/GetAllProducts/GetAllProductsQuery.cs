using eCommerce.Application.Features.Products.DTOs;
using Mediator;

namespace eCommerce.Application.Features.Products.Queries.GetAllProducts;

public sealed class GetAllProductsQuery : IRequest<List<GetAllProductsDTO>>
{
}
