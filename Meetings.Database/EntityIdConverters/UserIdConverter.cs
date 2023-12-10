using Meetings.Domain.Ids;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meetings.Database.EntityIdConverters;

public class UserIdConverter : ValueConverter<UserId, string>
{
    public UserIdConverter()
        : base(id => id.Value.ToString(), value => new UserId(value),
            new ConverterMappingHints(size: 26))
    {
    }
}