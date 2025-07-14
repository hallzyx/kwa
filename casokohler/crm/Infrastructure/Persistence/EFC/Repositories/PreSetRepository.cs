using casokohler.crm.Domain.Models.Aggregates;
using casokohler.crm.Domain.Models.ValueObjects;
using casokohler.crm.Domain.Repositories;
using kohler.Shared.Infrastructure.Persistence.EFC.Configuration;
using kohler.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace casokohler.crm.Infrastructure.Persistence.EFC.Repositories;

public class PreSetRepository(AppDbContext context): BaseRepository<PreSet>(context), IPreSetRepository
{
    public async Task<int> CountByShortNameAndProductIdAndMiraCustomerIdAsync(string shortName, string productId, string miraCustomerId)
    {
        var productIdGuid = new ProductId(Guid.Parse(productId));
        var miraCustomerIdGuid = new MiraCustomerId(Guid.Parse(miraCustomerId));
        return await Context.Set<PreSet>().Where(
            p=> p.ShortName == shortName &&
                p.ProductId == productIdGuid &&
                p.MiraCustomerId ==miraCustomerIdGuid
        ).CountAsync();
    }

    public async Task<int> CountByMiraCustomerIdAsync(string miraCustomerId)
    {
        return await Context.Set<PreSet>().Where(p => p.MiraCustomerId == new MiraCustomerId(Guid.Parse(miraCustomerId)))
            .CountAsync();
    }
}