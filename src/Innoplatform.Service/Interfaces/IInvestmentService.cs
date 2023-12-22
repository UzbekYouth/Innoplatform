using Innoplatform.Service.DTOs.Investments;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces;

public interface IInvestmentService
{
    public Task<bool> RemoveAsync(long id);
    public Task<InvestmentForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<InvestmentForResultDto>> GetAllAsync();
    public Task<InvestmentForResultDto> AddAsync(InvestmentForCreationDto dto);
    public Task<InvestmentForResultDto> ModifyAsync(long id, InvestmentForUpdateDto dto);
}
