using Meetings.Domain.Entities.Base;
using Meetings.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.Database.ValueObjectsConfigurations;

public static class DurationConfiguration
{
    public static OwnedNavigationBuilder<TEntity, TValueObject> ConfigureMeetingData<TEntity, TValueObject>(
        this OwnedNavigationBuilder<TEntity, TValueObject> ow)
        where TEntity : class, IEntity where TValueObject : MeetingData
    {
        ow.Property(x => x.From).IsRequired()
            .HasColumnName(nameof(MeetingData.From));
        ow.Property(x => x.To).IsRequired()
            .HasColumnName(nameof(MeetingData.To));
      
        return ow;
    }
}