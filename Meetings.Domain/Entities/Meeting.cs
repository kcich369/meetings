using Meetings.Domain.Entities.Base;
using Meetings.Domain.Ids;

namespace Meetings.Domain.Entities;

public sealed class Meeting : Entity<MeetingId>
{
    public string Description { get; private set; }

    //relation
    public AvailableDate AvailableDate { get; set; }

    private Meeting()
    {
    }

    public Meeting(MeetingId id, string description, AvailableDate availableDate)
    {
        Id = id;
        Description = description;
        AvailableDate = availableDate;
    }
}