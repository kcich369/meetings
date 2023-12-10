using Meetings.Domain.Ids.Base;

namespace Meetings.Domain.Ids;

public record UserId : EntityId
{
    public UserId() : base()
    {
    }
    public UserId(string value) : base(value)
    {
    }
};