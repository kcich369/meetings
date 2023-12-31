﻿using Meetings.Database.EntitiesConfigurations.Common;
using Meetings.Database.ValueObjectsConfigurations;
using Meetings.Domain.Entities;
using Meetings.Domain.Ids;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.Database.EntitiesConfigurations;

public class AvailableDateConfiguration : EntityConfiguration<AvailableDate, AvailableDateId>
{
    public AvailableDateConfiguration() : base("AvailableDates")
    {
    }

    protected override void ConfigureEntity(EntityTypeBuilder<AvailableDate> builder)
    {
        builder.OwnsOne(x => x.Duration, ow => ow.ConfigureDuration());
    }
}