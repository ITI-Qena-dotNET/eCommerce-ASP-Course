namespace eCommerce.Application.Features.Products.DTOs;

public sealed class UpdateProductDTO : InsertNewProductDTO
{
    public Guid ID { get; set; }
}
