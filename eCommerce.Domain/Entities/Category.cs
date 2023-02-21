namespace eCommerce.Domain.Entities;

public sealed class Category
{
    public int ID { get; set; }

    public string Name { get; set; }

    public Category? ParentCategory { get; set; }

    public IEnumerable<Category>? SubCategories { get; set; }

    public IEnumerable<Product> Products { get; set; }
}
