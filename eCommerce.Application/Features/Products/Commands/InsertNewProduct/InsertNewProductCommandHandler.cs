using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Domain.Contracts;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Data;
using Mediator;

namespace eCommerce.Application.Features.Products.Commands.InsertNewProduct;

public sealed class InsertNewProductCommandHandler : IRequestHandler<InsertNewProductCommand, GetAllProductsDTO>
{
    private readonly IProductRepository _repository;

    public InsertNewProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<GetAllProductsDTO> Handle(InsertNewProductCommand request, CancellationToken cancellationToken)
    {
        Product Product = new()
        {
            Name = request.dto.Name,
            Description = request.dto.Description,
            Price = request.dto.Price
        };

        await _repository.AddAsync(Product, cancellationToken);
        await _repository.CompleteWork(cancellationToken);

        return new()
        {
            ID = Product.ID,
            Name = Product.Name,
            Description = Product.Description,
            Price = Product.Price,
        };
    }
}
