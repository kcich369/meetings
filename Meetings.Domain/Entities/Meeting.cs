using Meetings.Domain.Entities.Base;
using Meetings.Domain.Ids;
using Meetings.Domain.ValueObjects;

namespace Meetings.Domain.Entities;

public sealed class Meeting : Entity<MeetingId>
{
    public UserData UserData { get; private set; }

    //relations
    public AvailableDateId AvailableDateId { get; set; }
    public AvailableDate AvailableDate { get; set; }

    public PaymentId PaymentId { get; set; }
    public Payment Payment { get; set; }

    private Meeting()
    {
    }

    public Meeting(MeetingId id, UserData userData, AvailableDateId availableDateId)
    {
        Id = id;
        UserData = userData;
        AvailableDateId = availableDateId;
    }

    public Meeting AddPayment(PaymentId paymentId)
    {
        PaymentId = paymentId;
        return this;
    }
}