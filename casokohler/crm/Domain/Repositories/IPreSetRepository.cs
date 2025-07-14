using casokohler.crm.Domain.Models.Aggregates;
using kohler.Shared.Domain.Repositories;

namespace casokohler.crm.Domain.Repositories;

public interface IPreSetRepository: IBaseRepository<PreSet>
{
    Task<int> CountByShortNameAndProductIdAndMiraCustomerIdAsync(
        string shortName,
        string productId,
        string miraCustomerId);
    
    Task<int> CountByMiraCustomerIdAsync(string miraCustomerId);
}