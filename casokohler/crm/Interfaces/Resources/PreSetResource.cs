namespace casokohler.crm.Interfaces.Resources;

public record PreSetResource(int  Id, string ProductId, string MiraCustomerId,
    string ShortName, double PreferredTemperature, double PreferredFlow, double PreferredDuration);
