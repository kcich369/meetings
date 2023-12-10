using Meetings.Domain.Ids.Base;

namespace Meetings.Domain.Ids;

public sealed record AvailableDateId : EntityId
{
    public AvailableDateId() : base()
    {
    }

    public AvailableDateId(string value) : base(value)
    {
    }
}