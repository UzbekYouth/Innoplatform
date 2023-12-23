using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces.IUserServices;

public interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> GetAllAsync(PaginationParams @params);
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    public Task<bool> ChangePasswordAsync(long id, UserPasswordForChangeDto dto);

}
