using Meetings.Domain.Ids;
using Meetings.Domain.Providers;
using Meetings.Domain.ValueObjects;

namespace Meetings.Infrastructure.Providers;

public class UserProvider : IUserProvider
{
    public UserData GetUser() => new UserData(){Id = new UserId(Ulid.NewUlid().ToString())};
}