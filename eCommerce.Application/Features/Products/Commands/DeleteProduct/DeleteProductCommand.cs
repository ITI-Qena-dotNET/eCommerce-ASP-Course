using Mediator;

namespace eCommerce.Application.Features.Products.Commands.DeleteProduct;

public sealed class DeleteProductCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
}
