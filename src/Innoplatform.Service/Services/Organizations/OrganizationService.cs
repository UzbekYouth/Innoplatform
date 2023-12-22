using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Organizations;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.Organizations;
using Innoplatform.Service.DTOs.ProjectAssets;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Innoplatform.Service.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organization> _repository;
        private readonly IFileUploadService _fileUploadService;
        private readonly IMapper _mapper;
        public OrganizationService(IRepository<Organization> repository, IMapper mapper, IFileUploadService fileUploadService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
        }

        public async Task<OrganizationForResultDto> AddAsync(OrganizationForCreationDto dto)
        {
            var Checking = await this._repository.SelectAll().Where(o => o.Email == dto.Email && o.CallCenter == dto.CallCenter && o.Name == dto.Name && o.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if(Checking != null)
            {
                throw new InnoplatformException(400, "This organization is exist");
            }
            var MappedData = this._mapper.Map<Organization>(dto);
            var asset = new AssetForCreationDto
            {
                FolderPath = "Organizations",
                FormFile = dto.ImagePath
            };

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            MappedData.ImagePath = assetPath?.AssetPath;

            var result = await this._repository.CreateAsync(MappedData);

            return this._mapper.Map<OrganizationForResultDto>(result);
        }

        public async Task<IEnumerable<OrganizationForResultDto>> GetAllAsync()
        {
            var result = await this._repository.SelectAll().Where(o => o.IsDeleted == false).AsNoTracking().ToListAsync();
            return this._mapper.Map<IEnumerable<OrganizationForResultDto>>(result);
        }   

        public async Task<OrganizationForResultDto> GetByIdAsync(long id)
        {
            var result = await this._repository.SelectAll().Where(o => o.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if(result == null)
            {
                throw new InnoplatformException(404, "Not Found");
            }
            return this._mapper.Map<OrganizationForResultDto>(result);
        }

        public async Task<OrganizationForResultDto> ModifyAsync(long id, OrganizationForUpdateDto dto)
        {
            var Checking = await this._repository.SelectAll().Where(o => o.Id == id && o.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if(Checking == null)
            {
                throw new InnoplatformException(404, "Not Found");
            }
            var MappedData = this._mapper.Map(dto, Checking);



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

                var assetPath = await _fileUploadService.FileUploadAsync(asset);
                MappedData.ImagePath = assetPath?.AssetPath;

            }
            else
            {
                MappedData.ImagePath = MappedData.ImagePath;
            }

            MappedData.UpdatedAt = DateTime.UtcNow;
            var result = await this._repository.UpdateAsync(MappedData);
            return this._mapper.Map<OrganizationForResultDto>(result);

        }

        public async Task<bool> RemoveAsync(long id)
        {
            var Checking = await this._repository.SelectAll().Where(o => o.Id == id && o.IsDeleted == false).AsNoTracking().FirstOrDefaultAsync();
            if (Checking == null)
            {
                throw new InnoplatformException(404, "Not Found");
            }
            if(Checking.ImagePath != null)
            {
                await _fileUploadService.DeleteFileAsync(Checking.ImagePath);
            }
            return await this._repository.DeleteAsync(id);
        }
    }
}
