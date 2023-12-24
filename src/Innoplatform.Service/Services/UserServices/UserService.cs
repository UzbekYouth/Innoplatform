using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Sponsors;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.Users;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Extensions;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Innoplatform.Service.Interfaces.IUserServices;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Innoplatform.Service.Services.UserServices;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Organization> _organizationRepository;
    private readonly IFileUploadService _fileUploadService;

    public UserService(
        IMapper mapper,
        IRepository<User> userRepository,
        IFileUploadService fileUploadService,
        IRepository<Organization> organizationRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _fileUploadService = fileUploadService;
        _organizationRepository = organizationRepository;
    }
    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var orgChecking = await _organizationRepository.SelectAll().Where(e => e.PhoneNumber == dto.PhoneNumber && e.Email == dto.Email && e.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
        
        if(orgChecking != null) 
        {
            throw new InnoplatformException(400, "This data is exist");
        }
        var user = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false && u.Email == dto.Email && u.PhoneNumber == dto.PhoneNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is not null)
            throw new InnoplatformException(409, "User with this email or phone number already exists");

        var mappedUser = _mapper.Map<User>(dto);
        if(dto.Image != null)
        {
            var asset = new AssetForCreationDto
            {
                FolderPath = "Users",
                FormFile = dto.Image
            };
            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mappedUser.Image = assetPath?.AssetPath;
        }

        var HashedPassword = PasswordHelper.Hash(dto.Password);
        mappedUser.Password = HashedPassword.Hash;
        mappedUser.Salt = HashedPassword.Salt;
        

        var createdUser = await _userRepository.CreateAsync(mappedUser);

        return _mapper.Map<UserForResultDto>(createdUser);
    }

    public async Task<bool> ChangePasswordAsync(long id, UserPasswordForChangeDto dto)
    {
        var data = await _userRepository
                        .SelectAll()
                        .Where(e => e.Id == id && e.IsDeleted == false)
                        .FirstOrDefaultAsync();
        if (data == null || PasswordHelper.Verify(dto.OldPassword, data.Salt, data.Password) == false)
        {
            throw new InnoplatformException(400, "User or Password is Incorrect");
        }
        else if (dto.NewPassword != dto.ConfirmPassword)
        {
            throw new InnoplatformException(400, "New Password and Confirm Password does not Match");
        }
        var HashedPassword = PasswordHelper.Hash(dto.ConfirmPassword);
        data.Salt = HashedPassword.Salt;
        data.Password = HashedPassword.Hash;
        await _userRepository.UpdateAsync(data);
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllAsync(PaginationParams @params)
    {
        var users = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false)
            .ToPagedList(@params)
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

        if (user.Image != null)
        {
            await _fileUploadService.DeleteFileAsync(user.Image);
        }

        return await _userRepository.DeleteAsync(id);
    }
}
