using Meetings.Domain.Entities;

namespace Meetings.Domain.Providers;

public interface IUserProvider
{
    User GetUser();
}