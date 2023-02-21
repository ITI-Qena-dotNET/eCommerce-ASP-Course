using Microsoft.Extensions.Logging;

namespace eCommerce.Infrastructure.Data;

public static class AppDbContextExtensions
{
    public static async Task SeedAsync(this AppDbContext context, ILogger<AppDbContext> logger)
    {

    }
}
