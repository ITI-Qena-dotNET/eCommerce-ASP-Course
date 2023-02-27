using eCommerce.Application.Features.Products.DTOs;
using Mediator;

namespace eCommerce.Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductCommand : IRequest<UpdateProductDTO>
{
    public UpdateProductDTO dto;

    public UpdateProductCommand(UpdateProductDTO dtoCommand)
    {
        dto = dtoCommand;
    }
}
