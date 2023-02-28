using Bogus;
using eCommerce.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace eCommerce.Infrastructure.Data;

public static class AppDbContextExtensions
{
    public static void SeedAsync(this AppDbContext context, ILogger<AppDbContext> logger)
    {
        var categoriesIds = 40;

        if (!context.Categories.Any())
        {
            var categoriesFaker = new Faker<Category>()
                .RuleFor(c => c.Name, f => f.Commerce.Categories(10)[0]);

            context.Categories.AddRange(categoriesFaker.Generate(categoriesIds));
            context.SaveChanges();
        }

        if (!context.Products.Any())
        {
            var productsFaker = new Faker<Product>()
                .RuleFor(c => c.Name, f => f.Commerce.ProductName())
                .RuleFor(c => c.Description, f => f.Commerce.ProductDescription().Substring(0, 20))
                .RuleFor(c => c.Price, f => decimal.Parse(f.Commerce.Price()));

            context.Products.AddRange(productsFaker.Generate(categoriesIds));
            context.SaveChanges();
        }
    }
}
