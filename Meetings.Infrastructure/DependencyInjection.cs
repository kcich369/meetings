using Meetings.Database;
using Meetings.Domain.Providers;
using Meetings.Infrastructure.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Meetings.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection serviceCollection,
        string connectionString)
    {
        serviceCollection.RegisterDatabase(connectionString);
        serviceCollection.AddSingleton<IDateProvider, DateProvider>();
        serviceCollection.AddSingleton<IUserProvider, UserProvider>();

        return serviceCollection;
    }
}