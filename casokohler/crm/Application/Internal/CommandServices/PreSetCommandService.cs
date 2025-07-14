using casokohler.crm.Domain.Models.Aggregates;
using casokohler.crm.Domain.Models.Commands;
using casokohler.crm.Domain.Repositories;
using casokohler.crm.Domain.Services;
using kohler.Shared.Domain.Repositories;

namespace casokohler.crm.Application.Internal.CommandServices;

public class PreSetCommandService(IPreSetRepository preSetRepository, IUnitOfWork unitOfWork) : IPreSetCommandService
{
    public async Task<PreSet?> Handle(CreatePreSetCommand command)
    {
        if(await preSetRepository.CountByShortNameAndProductIdAndMiraCustomerIdAsync(command.ShortName, command.ProductId, command.MiraCustomerId)>=1)
            throw new InvalidOperationException("There are already 2 PreSets with the same ShortName, ProductId and MiraCustomerId.");
        var countUserItems = await preSetRepository.CountByMiraCustomerIdAsync(command.MiraCustomerId);
        Console.WriteLine("Count of PreSets for MiraCustomerId: " + countUserItems);
        if(await preSetRepository.CountByMiraCustomerIdAsync(command.MiraCustomerId) >= 3)
            throw new InvalidOperationException("There are already 3 PreSets for this MiraCustomerId.");
        var newPreSet = new PreSet(command);
        await preSetRepository.AddAsync(newPreSet);
        await unitOfWork.CompleteAsync();
        return newPreSet;
    }
}