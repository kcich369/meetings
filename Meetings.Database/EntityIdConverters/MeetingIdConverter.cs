using Meetings.Domain.Ids;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meetings.Database.EntityIdConverters;

public class MeetingIdConverter: ValueConverter<MeetingId, string>
{
    public MeetingIdConverter()
        : base(id => id.Value.ToString(), value => new MeetingId(value),
            new ConverterMappingHints(size: 26))
    {
    }
}