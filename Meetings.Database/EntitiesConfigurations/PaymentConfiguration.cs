using Meetings.Database.EntitiesConfigurations.Common;
using Meetings.Database.ValueObjectsConfigurations;
using Meetings.Domain.Entities;
using Meetings.Domain.Ids;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.Database.EntitiesConfigurations;

public class PaymentConfiguration : EntityConfiguration<Payment, PaymentId>
{
    public PaymentConfiguration() : base("Payments")
    {
    }

    protected override void ConfigureEntity(EntityTypeBuilder<Payment> builder)
    {
        builder.OwnsOne(x => x.Amount, ow => ow.ConfigureAmount());
    }
}