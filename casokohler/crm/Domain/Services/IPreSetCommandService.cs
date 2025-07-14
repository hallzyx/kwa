using casokohler.crm.Domain.Models.Aggregates;
using casokohler.crm.Domain.Models.Commands;

namespace casokohler.crm.Domain.Services;

public interface IPreSetCommandService
{
    Task<PreSet?> Handle(CreatePreSetCommand command);
}