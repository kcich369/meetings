using Meetings.Database.EntitiesConfigurations.Common;
using Meetings.Database.ValueObjectsConfigurations;
using Meetings.Domain.Entities;
using Meetings.Domain.Ids;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.Database.EntitiesConfigurations;

public class MeetingConfiguration: EntityConfiguration<Meeting, MeetingId>
{
    public MeetingConfiguration() : base("Meetings")
    {
    }

    protected override void ConfigureEntity(EntityTypeBuilder<Meeting> builder)
    {
        builder.HasOne(x => x.Payment).WithOne(x=>x.Meeting)
            .HasForeignKey<Meeting>(x => x.PaymentId);
        builder.HasOne(x => x.AvailableDate).WithOne(x=>x.Meeting)
            .HasForeignKey<Meeting>(x => x.AvailableDateId);
        
        builder.OwnsOne(x => x.UserData, ow => ow.ConfigureUserData());
    }
}