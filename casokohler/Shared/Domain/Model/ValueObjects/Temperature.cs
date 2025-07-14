namespace casokohler.Shared.Domain.Model.ValueObjects;

public record Temperature
{
    public double Value { get; init; }
    
    public Temperature(double value)
    {
        if(value is <1 or > 65)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Temperature value must be between 1 and 65");
        }
        Value = value;
    }
}