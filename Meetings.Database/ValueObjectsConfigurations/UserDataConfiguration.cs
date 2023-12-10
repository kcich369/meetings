using Meetings.Database.EntityIdConverters;
using Meetings.Domain.Entities.Base;
using Meetings.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.Database.ValueObjectsConfigurations;

public static class UserDataConfiguration
{
    public static OwnedNavigationBuilder<TEntity, TValueObject> ConfigureUserData<TEntity, TValueObject>(
        this OwnedNavigationBuilder<TEntity, TValueObject> ow)
        where TEntity : class, IEntity where TValueObject : UserData
    {
        ow.Property(x => x.Id)
            .HasColumnName(nameof(UserData.Id));
        ow.Property(x=>x.Id).HasConversion(new UserIdConverter());
        return ow;
    }
}