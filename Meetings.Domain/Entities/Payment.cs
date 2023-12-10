using Meetings.Domain.Entities.Base;
using Meetings.Domain.Ids;
using Meetings.Domain.ValueObjects;

namespace Meetings.Domain.Entities;

public class Payment : Entity<PaymentId>
{
    public Amount Amount { get; set; }
    
    public MeetingId MeetingId { get; private set; }
    public Meeting Meeting { get; private set; }
    private Payment()
    {
    }

    public Payment(Amount amount)
    {
        Amount = amount;
    }
}