using Meetings.Domain.ValueObjects;

namespace Meetings.Domain.Providers;

public interface IUserProvider
{
    UserData GetUser();
}