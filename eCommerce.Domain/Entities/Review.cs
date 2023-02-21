namespace eCommerce.Domain.Entities;

public sealed class Review
{
    public int ID { get; set; }

    public string Comment { get; set; }

    public DateTimeOffset ReviewDate { get; set; }

    public Product Product { get; set; }
}
