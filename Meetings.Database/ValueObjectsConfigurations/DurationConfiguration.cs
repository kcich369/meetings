using Meetings.Domain.Entities.Base;
using Meetings.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.Database.ValueObjectsConfigurations;

public static class DurationConfiguration
{
    public static OwnedNavigationBuilder<TEntity, TValueObject> ConfigureDuration<TEntity, TValueObject>(
        this OwnedNavigationBuilder<TEntity, TValueObject> ow)
        where TEntity : class, IEntity where TValueObject : Duration
    {
        ow.Property(x => x.From).IsRequired()
            .HasColumnName(nameof(Duration.From));
        ow.Property(x => x.To).IsRequired()
            .HasColumnName(nameof(Duration.To));
      
        return ow;
    }
}