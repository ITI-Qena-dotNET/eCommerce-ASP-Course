using eCommerce.Application.Features.Products.DTOs;
using MediatR;

namespace eCommerce.Application.Features.Products.Commands.InsertNewProduct;

public sealed class InsertNewProductCommand : IRequest<GetAllProductsDTO>
{
    public InsertNewProductDTO dto;

    public InsertNewProductCommand(InsertNewProductDTO dtoCommand)
    {
        dto = dtoCommand;
    }
}
