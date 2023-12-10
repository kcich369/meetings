using Meetings.Domain.Ids.Base;

namespace Meetings.Domain.Ids;

public record PaymentId : EntityId
{
    public PaymentId() : base()
    {
    }
    public PaymentId(string value) : base(value)
    {
    }
}