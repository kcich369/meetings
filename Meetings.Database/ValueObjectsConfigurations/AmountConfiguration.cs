using Meetings.Domain.Entities.Base;
using Meetings.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.Database.ValueObjectsConfigurations;

public static class AmountConfiguration
{
    public static OwnedNavigationBuilder<TEntity, TValueObject> ConfigureAmount<TEntity, TValueObject>(
        this OwnedNavigationBuilder<TEntity, TValueObject> ow)
        where TEntity : class, IEntity where TValueObject : Amount
    {
        ow.Property(x => x.Currency).IsRequired().HasMaxLength(4)
            .HasColumnName(nameof(Amount.Currency));
        ow.Property(x => x.Decimal).IsRequired()
            .HasColumnName(nameof(Amount.Decimal));
        ow.Property(x => x.Value).IsRequired()
            .HasColumnName(nameof(Amount.Value));
        ow.Property(x => x.TotalPart).IsRequired()
            .HasColumnName(nameof(Amount.TotalPart));
        return ow;
    }
}