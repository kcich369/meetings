using Meetings.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Meetings.Database.Extensions;

public static class DbExtension
{
    public static async Task MigrateDatabase(this IServiceCollection serviceCollection)
    {
        using var scope = serviceCollection.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<AppDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}