using Meetings.Domain.Providers;

namespace Meetings.Infrastructure.Providers;

public class DateProvider : IDateProvider
{
    public DateTimeOffset DateTimeNow() => DateTimeOffset.Now;
}