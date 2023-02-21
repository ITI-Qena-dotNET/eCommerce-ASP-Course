using Microsoft.EntityFrameworkCore;
using Polly;

namespace eCommerce_ASP_Course.Extensions;

public static class HostExtensions
{
    public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}...", typeof(TContext).Name);

                var retry = Policy.Handle<Exception>()
                        .WaitAndRetry(
                            retryCount: 3,
                            sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                            onRetry: (exception, retryCount, context) =>
                            {
                                logger.LogError($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                            });

                retry.Execute(() => InvokeSeeder(seeder!, context!, services));

                logger.LogInformation("Migrated database associated with context {DbContextName}.", typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
            }
        }

        return host;
    }

    private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context,
                                                IServiceProvider services) where TContext : DbContext
    {
        // Can be removed if the same database is needed
        // To be removed in Production
        //context.Database.EnsureDeleted();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.EnsureCreated();
        }

        seeder(context, services);
    }
}
