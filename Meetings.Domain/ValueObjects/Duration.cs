namespace Meetings.Domain.ValueObjects;

public sealed class Duration
{
    public DateTimeOffset From { get; private set; }
    public DateTimeOffset To { get; private set; }
}