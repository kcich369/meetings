namespace Meetings.Domain.Providers;

public interface IDateProvider
{
    DateTimeOffset DateTimeNow();
}