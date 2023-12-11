using Meetings.Domain.Entities;

namespace Meetings.Domain.ValueObjects;

public class MeetingData
{
    public DateOnly Date { get; set; }
    public TimeOnly From { get; init; }
    public TimeOnly To { get; init;  }

    public MeetingData(DateOnly date, TimeOnly from, TimeOnly to)
    {
        Date = date;
        From = from;
        To = to;
    }
}