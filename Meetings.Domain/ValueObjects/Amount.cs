namespace Meetings.Domain.ValueObjects;

public class Amount
{
    public decimal Value { get; set; }
    public string Currency { get; set; }
    public uint TotalPart { get; set; }
    public uint Decimal { get; set; }

    public Amount(decimal value, string currency, uint totalPart, uint @decimal)
    {
        Value = value;
        Currency = currency;
        TotalPart = totalPart;
        Decimal = @decimal;
    }
}