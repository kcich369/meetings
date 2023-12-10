using Meetings.Domain.Auditable;
using Meetings.Domain.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Meetings.Database.Interceptors;

public sealed class UpdatingAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    private readonly IDateProvider _dateProvider;
    private readonly IUserProvider _userProvider;

    public UpdatingAuditableEntitiesInterceptor(IDateProvider dateProvider, IUserProvider userProvider)
    {
        _dateProvider = dateProvider;
        _userProvider = userProvider;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
    {
        var context = eventData.Context;
        if (context is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        var entries = context.ChangeTracker.Entries<IUpdateInfo>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Modified)
                entry.Entity.SetUpdateInfoData(_dateProvider.DateTimeNow(), _userProvider.GetUser().Id, "admin");
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}