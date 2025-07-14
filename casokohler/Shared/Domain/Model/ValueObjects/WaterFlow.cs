namespace casokohler.Shared.Domain.Model.ValueObjects;

public record WaterFlow
{
    public double Value { get; init; }
    public WaterFlow(double value)
    {
        if (value is < 4 or > 16)
        {
            throw new ArgumentException("Water flow value must be between 4 and 16.", nameof(value));
        }
        Value = value;
    }
}