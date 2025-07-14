namespace casokohler.crm.Interfaces.Resources;

public record CreatePreSetResource(
    string ShortName, double PreferredTemperature, double PreferredFlow, double PreferredDuration);
