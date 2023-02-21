namespace eCommerce.Domain.Entities;

public sealed class Product
{
    public Guid ID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public IEnumerable<Category> Categories { get; set; }

    public IEnumerable<Review> Reviews { get; set; }

    public IEnumerable<OrderDetail> OrderDetails { get; set; }
}
