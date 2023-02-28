using eCommerce.Domain.Contracts;
using Mediator;

namespace eCommerce.Application.Features.Products.Commands.DeleteProduct;

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var affected = await _repository.DeleteAsync(request.ID, cancellationToken);
        return Unit.Value;
    }
}
