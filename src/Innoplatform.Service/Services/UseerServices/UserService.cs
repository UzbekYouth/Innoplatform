using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.Users;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.UseerServices;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;

    public UserService(IMapper mapper, IRepository<User> userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Email == dto.Email && u.PhoneNumber == dto.PhoneNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is not null)
            throw new InnoplatformException(409, "User with this email or phone number already exists");

        var mappedUser = _mapper.Map<User>(dto);

        var createdUser = await _userRepository.CreateAsync(mappedUser);

        return _mapper.Map<UserForResultDto>(createdUser);
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllAsync()
    {
        var users = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User not found");

        return _mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User not found");

        var mappedUser = _mapper.Map(dto, user);
        mappedUser.UpdatedAt = DateTime.UtcNow;

        var updatedUser = await _userRepository.UpdateAsync(mappedUser);

        return _mapper.Map<UserForResultDto>(updatedUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User not found");

        return await _userRepository.DeleteAsync(id);
    }
}
