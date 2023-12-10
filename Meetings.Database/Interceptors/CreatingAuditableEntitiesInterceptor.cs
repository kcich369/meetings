using Meetings.Domain.Auditable;
using Meetings.Domain.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Meetings.Database.Interceptors;

public sealed class CreatingAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    private readonly IDateProvider _provider;
    private readonly IUserProvider _userProvider;

    public CreatingAuditableEntitiesInterceptor(IDateProvider provider, IUserProvider userProvider)
    {
        _provider = provider;
        _userProvider = userProvider;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
    {
        var context = eventData.Context;
        if (context is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        var entries = context.ChangeTracker.Entries<ICreationInfo>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Entity.SetCreationInfo(_provider.DateTimeNow(), _userProvider.GetUser().Id, "admin");
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}