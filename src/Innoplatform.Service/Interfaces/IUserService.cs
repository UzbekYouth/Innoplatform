﻿using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces;

public interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> GetAllAsync();
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
}
