using Microsoft.Extensions.DependencyInjection;

namespace Meetings.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(
            config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return serviceCollection;
    }
}