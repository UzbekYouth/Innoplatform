﻿using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.Organizations;
using Innoplatform.Service.DTOs.ProjectAssets;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Extensions;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Innoplatform.Service.Interfaces.IOrganizationServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Innoplatform.Service.Services.OrganizationServices
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organization> _repository;
        private readonly IRepository<User> _userRepository;
        private readonly IFileUploadService _fileUploadService;
        private readonly IMapper _mapper;
        public OrganizationService(IRepository<Organization> repository, IMapper mapper, IFileUploadService fileUploadService, IRepository<User> userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
            _userRepository = userRepository;
        }

        public async Task<OrganizationForResultDto> AddAsync(OrganizationForCreationDto dto)
        {
            var UserPhoneChecking = await _userRepository.SelectAll().Where(e => e.PhoneNumber == dto.PhoneNumber || e.Email == dto.Email && e.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if (UserPhoneChecking != null)
            {
                throw new InnoplatformException(400, "This Data is exist");
            }
            var Checking = await _repository.SelectAll()
                .Where(o => (o.Email == dto.Email || o.PhoneNumber == dto.PhoneNumber) && o.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (Checking != null)
            {
                throw new InnoplatformException(400, "This organization is exist");
            }
            var MappedData = _mapper.Map<Organization>(dto);
            if(dto.ImagePath != null)
            {
                var asset = new AssetForCreationDto
                {
                    FolderPath = "Organizations",
                    FormFile = dto.ImagePath
                };

                if (asset.FormFile.ContentType != "image/jpeg" && asset.FormFile.ContentType != "image/png" && asset.FormFile.ContentType != "image/jpg" && asset.FormFile.ContentType != "image/HEIC")
                {
                    throw new InnoplatformException(400, "Image is not valid");
                }

                var assetPath = await _fileUploadService.FileUploadAsync(asset);

                MappedData.ImagePath = assetPath?.AssetPath;
            }

            var HashedPassword = PasswordHelper.Hash(dto.Password);

            MappedData.Password = HashedPassword.Hash;
            MappedData.Salt = HashedPassword.Salt;

            var result = await _repository.CreateAsync(MappedData);

            return _mapper.Map<OrganizationForResultDto>(result);
        }

        public async Task<bool> ChangePasswordAsync(long Id, OrganizationPasswordForChangeDto dto)
        {
            var data = await _repository
                        .SelectAll()
                        .Where(e => e.Id == Id && e.IsDeleted == false)
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
            await _repository.UpdateAsync(data);
            return true;
        }

        public async Task<IEnumerable<OrganizationForResultDto>> GetAllAsync(PaginationParams @params)
        {
            var result = await _repository.SelectAll()
                .Where(o => o.IsDeleted == false)
                .ToPagedList(@params)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<IEnumerable<OrganizationForResultDto>>(result);
        }

        public async Task<OrganizationForResultDto> GetByIdAsync(long id)
        {
            var result = await _repository.SelectAll()
                .Where(o => o.IsDeleted == false && o.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (result == null)
            {
                throw new InnoplatformException(404, "Not Found");
            }
            return _mapper.Map<OrganizationForResultDto>(result);
        }

        public async Task<OrganizationForResultDto> ModifyAsync(long id, OrganizationForUpdateDto dto)
        {
            var Checking = await _repository.SelectAll().Where(o => o.Id == id && o.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if (Checking == null)
            {
                throw new InnoplatformException(404, "Not Found");
            }
            var MappedData = _mapper.Map(dto, Checking);

            if (dto != null && dto.ImagePath != null)
            {
                if (MappedData.ImagePath != null)
                {
                    await _fileUploadService.DeleteFileAsync(MappedData.ImagePath);
                }
                var asset = new AssetForCreationDto
                {
                    FolderPath = "Organizations",
                    FormFile = dto.ImagePath
                };

                if (asset.FormFile.ContentType != "image/jpeg" && asset.FormFile.ContentType != "image/png" && asset.FormFile.ContentType != "image/jpg" && asset.FormFile.ContentType != "image/HEIC")
                {
                    throw new InnoplatformException(400, "Image is not valid");
                }
                var assetPath = await _fileUploadService.FileUploadAsync(asset);
                MappedData.ImagePath = assetPath?.AssetPath;

            }
            else
            {
                MappedData.ImagePath = MappedData.ImagePath;
            }

            MappedData.UpdatedAt = DateTime.UtcNow;
            var result = await _repository.UpdateAsync(MappedData);
            return _mapper.Map<OrganizationForResultDto>(result);

        }

        public async Task<bool> RemoveAsync(long id)
        {
            var Checking = await _repository.SelectAll().Where(o => o.Id == id && o.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if (Checking == null)
            {
                throw new InnoplatformException(404, "Not Found");
            }
            if (Checking.ImagePath != null)
            {
                await _fileUploadService.DeleteFileAsync(Checking.ImagePath);
            }
            return await _repository.DeleteAsync(id);
        }
    }
}
