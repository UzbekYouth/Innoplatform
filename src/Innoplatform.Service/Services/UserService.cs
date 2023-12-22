using Innoplatform.Service.DTOs.Users;
using Innoplatform.Service.Interfaces;

namespace Innoplatform.Service.Services;

public class UserService : IUserService
{
    public Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    { 
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }
}
