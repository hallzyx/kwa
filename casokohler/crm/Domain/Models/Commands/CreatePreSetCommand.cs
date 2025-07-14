namespace casokohler.crm.Domain.Models.Commands;

public record CreatePreSetCommand(
    string ProductId, 
    string MiraCustomerId, 
    string ShortName, 
    double PreferredTemperature,
    double PreferredDuration,
    double PreferredFlow);