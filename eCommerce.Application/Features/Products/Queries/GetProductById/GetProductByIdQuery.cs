using eCommerce.Application.Features.Products.DTOs;
using Mediator;

namespace eCommerce.Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdQuery : IRequest<GetAllProductsDTO>
{
    public Guid ID { get; set; }
}
