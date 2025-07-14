using casokohler.crm.Domain.Models.Aggregates;
using casokohler.crm.Interfaces.Resources;

namespace casokohler.crm.Interfaces.Transform;

public static class PreSetResourceFromEntityAssembler
{
    public static PreSetResource ToPreSetResourceFromEntity(PreSet Entity)
    {
        return new PreSetResource(
            Entity.Id,
            Entity.ProductId.Id.ToString(),
            Entity.MiraCustomerId.Id.ToString(),
            Entity.ShortName,
            Entity.PreferredTemperature.Value,
            Entity.PreferredFlow.Value,
            Entity.PreferredDuration.Value
        );
    }

}