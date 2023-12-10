using Meetings.Domain.Entities.Base;
using Meetings.Domain.Ids;

namespace Meetings.Domain.Entities;

public class User : Entity<MeetingId>
{
    public UserId Id { get; private set; }
    public string Email { get; private set; }
    public UserId PhoneNumber { get; private set; }

    private User()
    {
    }

    public User(UserId id)
    {
        Id = id;
    }
}