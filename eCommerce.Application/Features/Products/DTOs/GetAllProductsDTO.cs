namespace eCommerce.Application.Features.Products.DTOs;

public sealed class GetAllProductsDTO
{
    public Guid ID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}
