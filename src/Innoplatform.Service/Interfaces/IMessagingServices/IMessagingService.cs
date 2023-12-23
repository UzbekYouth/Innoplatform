using Innoplatform.Service.DTOs.Messages;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces;

public interface IMessagingService
{
    public Task<bool> RemoveAsync(long id);
    public Task<MessagingForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<MessagingForResultDto>> GetAllAsync();
    public Task<MessagingForResultDto> AddAsync(MessagingForCreationDto dto);
    public Task<MessagingForResultDto> ModifyAsync(long id, MessagingForUpdateDto dto);
}
