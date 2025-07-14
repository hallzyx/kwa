namespace casokohler.Shared.Domain.Model.ValueObjects;

public record Duration
{
    public double Value { get; init; }
    public Duration(double value)
    {
        if (value is < 0 or > 240)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Duration value must be between 0 and 240.");
        }

        Value = value;
    }
};