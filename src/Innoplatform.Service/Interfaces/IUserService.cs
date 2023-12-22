using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces;

public interface IUserService
{
    public Task<IEnumerable<UserForResultDto>> GetAllAsync();
    public Task<UserForResultDto> GetByIdAsync(long id);
    public Task<UserForResultDto> AddAsync(UserForCreationDto userForCreationDto);
    public Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto userForUpdateDto);
    public Task<bool> RemoveAsync(long id);
}
