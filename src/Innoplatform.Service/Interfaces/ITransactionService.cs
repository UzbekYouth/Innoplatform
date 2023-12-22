using Innoplatform.Service.DTOs.Transactions;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces;

public interface ITransactionService
{
    public Task<bool> RemoveAsync(long id);
    public Task<TransactionForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<TransactionForResultDto>> GetAllAsync();
    public Task<TransactionForResultDto> AddAsync(TransactionForCreationDto dto);
}
