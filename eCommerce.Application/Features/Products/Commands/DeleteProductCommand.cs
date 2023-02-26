using MediatR;

namespace eCommerce.Application.Features.Products.Commands;

public sealed class DeleteProductCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
}
