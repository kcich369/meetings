using Meetings.Database.Context;
using Meetings.Database.Interceptors;
using Meetings.Database.Repositories;
using Meetings.Domain.Repositories;
using Meetings.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Meetings.Database;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection serviceCollection,
        string connectionString)
    {
        serviceCollection.AddSingleton<CreatingAuditableEntitiesInterceptor>();
        serviceCollection.AddSingleton<UpdatingAuditableEntitiesInterceptor>();

        serviceCollection.AddDbContext<IAppDbContext, AppDbContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(connectionString)
                .AddInterceptors(serviceProvider.GetRequiredService<CreatingAuditableEntitiesInterceptor>(),
                    serviceProvider.GetRequiredService<UpdatingAuditableEntitiesInterceptor>()
                );
        });
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        serviceCollection.AddScoped<IAvailableDateRepository, IAvailableDateRepository>();
        serviceCollection.AddScoped<IMeetingRepository, MeetingRepository>();

        return serviceCollection;
    }
}