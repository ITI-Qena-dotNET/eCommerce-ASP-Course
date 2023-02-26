using eCommerce.Application.Features.Products.DTOs;
using MediatR;

namespace eCommerce.Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdQuery : IRequest<GetAllProductsDTO>
{
    public Guid ID { get; set; }
}
