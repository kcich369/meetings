using Meetings.Database.EntitiesConfigurations.Common.Converters;
using Meetings.Database.ValueObjectsConfigurations;
using Meetings.Domain.Entities.Base;
using Meetings.Domain.Exceptions;
using Meetings.Domain.Ids.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.Database.EntitiesConfigurations.Common;

public abstract class EntityConfiguration<T, TId> : IEntityTypeConfiguration<T>
    where T : Entity<TId> where TId : EntityId
{
    private readonly string _tableName;

    protected EntityConfiguration(string tableName)
    {
        _tableName = tableName;
    }

    public void Configure(EntityTypeBuilder<T> builder)
    {
        if (_tableName is null)
            throw new InvalidTableNameException("Table name can not be null");

        builder.ToTable(_tableName);
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(x => !x.Deleted);
        builder.Property(x => x.Version).IsRowVersion().ValueGeneratedOnAddOrUpdate();

        builder.OwnsOne(x => x.CreationInfo, ow => ow.ConfigureCreationInfo());
        builder.OwnsOne(x => x.UpdateInfo, ow => ow.ConfigureUpdateInfo());
        builder.SetConverters();
        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}