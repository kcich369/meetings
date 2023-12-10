using Meetings.Domain.Entities.Base;
using Meetings.Domain.Ids;
using Meetings.Domain.ValueObjects;

namespace Meetings.Domain.Entities;

public sealed class AvailableDate :Entity<AvailableDateId>
{
    public Duration Duration { get; private set; }

    private AvailableDate()
    {
    }

    public AvailableDate(AvailableDateId id, Duration duration)
    {
        Id = id;
        Duration = duration;
    }
}