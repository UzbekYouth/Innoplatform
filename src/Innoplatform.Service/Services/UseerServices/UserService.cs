using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.Sponsors;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.Users;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.UseerServices;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IFileUploadService _fileUploadService;

    public UserService(
        IMapper mapper, 
        IRepository<User> userRepository,
        IFileUploadService fileUploadService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _fileUploadService = fileUploadService;
    }
    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Email == dto.Email && u.PhoneNumber == dto.PhoneNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is not null)
            throw new InnoplatformException(409, "User with this email or phone number already exists");

        var asset = new AssetForCreationDto
        {
            FolderPath = "Users",
            FormFile = dto.Image
        };

        var assetPath = await _fileUploadService.FileUploadAsync(asset);

        var mappedUser = _mapper.Map<User>(dto);
        mappedUser.Image = assetPath?.AssetPath;

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

        if (dto != null && dto.Image != null)
        {
            if (user != null)
            {
                await _fileUploadService.DeleteFileAsync(user.Image);
            }
            var asset = new AssetForCreationDto
            {
                FolderPath = "Sponsors",
                FormFile = dto.Image
            };

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mappedUser.Image = assetPath?.AssetPath;

        }
        else
        {
            mappedUser.Image = mappedUser.Image;
        }

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

        if(user.Image != null)
        {
            await _fileUploadService.DeleteFileAsync(user.Image);
        }

        return await _userRepository.DeleteAsync(id);
    }
}
