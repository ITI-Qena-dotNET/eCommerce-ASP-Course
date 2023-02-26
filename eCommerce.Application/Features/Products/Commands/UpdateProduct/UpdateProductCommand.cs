using eCommerce.Application.Features.Products.DTOs;
using MediatR;

namespace eCommerce.Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductCommand : IRequest<UpdateProductDTO>
{
    public UpdateProductDTO dto;

    public UpdateProductCommand(UpdateProductDTO dtoCommand)
    {
        dto = dtoCommand;
    }
}
