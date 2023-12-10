namespace Meetings.Domain.Ids.Base;

public abstract record EntityId
{
    public Ulid Value { get; init; }

    protected EntityId()
    {
        Value = new Ulid();
    }

    protected EntityId(Ulid value)
    {
        Value = value;
    }

    public override string ToString() => Value.ToString();
}