namespace Meetings.Domain.ValueObjects;

public class Duration
{
    public DateTimeOffset From { get; init; }
    public DateTimeOffset To { get; init;  }

    public Duration(DateTimeOffset from, DateTimeOffset to)
    {
        From = from;
        To = to;
    }
}