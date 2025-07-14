using casokohler.crm.Domain.Models.Commands;
using casokohler.crm.Interfaces.Resources;

namespace casokohler.crm.Interfaces.Transform;

public static class CreatePreSetCommandFromResourceAssembler
{
    
    public static CreatePreSetCommand ToCreatePreSetCommandFromResource(string productId, string customerId,CreatePreSetResource resource)
    {
        return new CreatePreSetCommand(
            productId,
            customerId,
            resource.ShortName,
            resource.PreferredTemperature,
            resource.PreferredDuration,
            resource.PreferredFlow
        );
    }
}