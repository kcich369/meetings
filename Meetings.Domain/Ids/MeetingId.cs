using Meetings.Domain.Ids.Base;

namespace Meetings.Domain.Ids;

public sealed record MeetingId : EntityId
{
    public MeetingId() : base()
    {
    }
    public MeetingId(string value) : base(value)
    {
    }
}
