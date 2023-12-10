using Meetings.Domain.Ids;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meetings.Database.EntityIdConverters;

public class AvailableDateIdConverter: ValueConverter<AvailableDateId, string>
{
    public AvailableDateIdConverter()
        : base(id => id.Value.ToString(), value => new AvailableDateId(value),
            new ConverterMappingHints(size: 26))
    {
    }
}