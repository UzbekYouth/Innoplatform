using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces.IInvestmentServices;

public interface IInvestmentAreaService
{
    public Task<bool> RemoveAsync(long id);
    public Task<InvestmentAreaForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<InvestmentAreaForResultDto>> GetAllAsync();
    public Task<InvestmentAreaForResultDto> AddAsync(InvestmentAreaForCreationDto dto);
    public Task<InvestmentAreaForResultDto> ModifyAsync(long id, InvestmentAreaForUpdateDto dto);
}
