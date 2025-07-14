using casokohler.crm.Domain.Models.Commands;
using casokohler.crm.Domain.Models.ValueObjects;
using casokohler.Shared.Domain.Model.ValueObjects;

namespace casokohler.crm.Domain.Models.Aggregates;

public class PreSet
{
    public int Id { get; set; }
    public ProductId ProductId { get; set; }
    public MiraCustomerId MiraCustomerId { get; set; }
    public string ShortName { get; set; }
    public Temperature PreferredTemperature { get; set; }
    public WaterFlow PreferredFlow { get; set; }
    public Duration PreferredDuration { get; set; }
    
    public PreSet(){}

    public PreSet(CreatePreSetCommand command)
    {
        if(command.ShortName.Length==0)
            throw new ArgumentException("Short name cannot be empty.", nameof(command.ShortName));
        ProductId = new ProductId(Guid.Parse(command.ProductId));
        MiraCustomerId = new MiraCustomerId(Guid.Parse(command.MiraCustomerId));
        ShortName = command.ShortName;
        PreferredTemperature = new Temperature(command.PreferredTemperature);
        PreferredFlow = new WaterFlow(command.PreferredFlow);
        PreferredDuration = new Duration(command.PreferredDuration);
    }
}