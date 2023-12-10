using Meetings.Database.EntityIdConverters;
using Meetings.Domain.Entities.Base;
using Meetings.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.Database.ValueObjectsConfigurations;

public static class CreationInfoConfiguration
{
    public static OwnedNavigationBuilder<TEntity, TValueObject> ConfigureCreationInfo<TEntity, TValueObject>(
        this OwnedNavigationBuilder<TEntity, TValueObject> ow)
        where TEntity : class, IEntity where TValueObject : CreationInfo
    {
        ow.Property(x => x.CreatedAt).IsRequired()
            .HasColumnName(nameof(CreationInfo.CreatedAt));
        ow.Property(x => x.CreatedBy).IsRequired().HasMaxLength(100)
            .HasColumnName(nameof(CreationInfo.CreatedBy));
        ow.Property(x => x.CreatedById).IsRequired()
            .HasColumnName(nameof(CreationInfo.CreatedById));
        ow.Property(x=>x.CreatedById).HasConversion(new UserIdConverter());
        return ow;
    }
}