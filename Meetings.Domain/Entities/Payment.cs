using Meetings.Domain.Entities.Base;
using Meetings.Domain.Ids;
using Meetings.Domain.ValueObjects;

namespace Meetings.Domain.Entities;

public sealed class Payment : Entity<PaymentId>
{
    public Amount Amount { get; set; }

    //relations
    public MeetingId MeetingId { get; private set; }
    public Meeting Meeting { get; private set; }

    private Payment()
    {
    }

    public Payment(Amount amount, MeetingId meetingId)
    {
        Amount = amount;
        MeetingId = meetingId;
    }
}