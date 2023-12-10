using Meetings.Domain.Ids;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meetings.Database.EntityIdConverters;

public class PaymentIdConverter: ValueConverter<PaymentId, string>
{
    public PaymentIdConverter()
        : base(id => id.Value.ToString(), value => new PaymentId(value),
            new ConverterMappingHints(size: 26))
    {
    }
}