using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces;

public interface IUserService
{
    public Task<bool> RemoveAsync(long id);
    public Task<UserForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<UserForResultDto>> GetAllAsync();
    public Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    public Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
}
