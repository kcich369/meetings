using Meetings.Domain.Entities.Base;
using Meetings.Domain.Ids;
using Meetings.Domain.ValueObjects;

namespace Meetings.Domain.Entities;

public sealed class AvailableDate :Entity<AvailableDateId>
{
    public MeetingData MeetingData { get; private set; }
    //relations
    public MeetingId MeetingId { get; private set; }
    public Meeting Meeting { get; private set; }

    private AvailableDate()
    {
    }

    public AvailableDate(AvailableDateId id, MeetingData meetingData)
    {
        Id = id;
        MeetingData = meetingData;
    }
}