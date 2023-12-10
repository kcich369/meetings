namespace Meetings.Domain.Ids.Base;

public abstract record EntityId
{
    public Ulid Value { get; init; }

    protected EntityId()
    {
        Value = new Ulid();
    }

    protected EntityId(string value)
    {
        Value =  Ulid.Parse(value);
    }

    public static implicit operator string(EntityId id) => id.ToString();
    public override string ToString() => Value.ToString() ?? string.Empty;
}