using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace eCommerce.Application.Features.Products.Commands.PatchProduct;

public sealed class PatchProductQuery : IRequest<GetAllProductsDTO>
{
    public required Guid ID { get; set; }

    public required JsonPatchDocument<Product> PatchUpdates { get; set; }
}
