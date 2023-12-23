using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.About;
using Innoplatform.Domain.Entities.Sponsors;
using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Innoplatform.Service.Interfaces.IAboutServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.AboutServices;

public class AboutUsAssetService : IAboutUsAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<AboutUsAsset> _repository;
    private readonly IFileUploadService _fileUploadService;

    public AboutUsAssetService(
        IMapper mapper, 
        IRepository<AboutUsAsset> repository,
        IFileUploadService fileUploadService)
    {
        _mapper = mapper;
        _repository = repository;
        _fileUploadService = fileUploadService;
    }
    public async Task<AboutUsAssetForResultDto> AddAsync(AboutUsAssetForCreationDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AbouteUsId == dto.AbouteUsId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity is not null)
            throw new InnoplatformException(400, "aboutUsAsset is already exist");

        var existAsset = await _repository.SelectAll()
            .Where(ea => ea.AbouteUsId == dto.AbouteUsId && ea.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (existAsset is null)
            throw new InnoplatformException(400, "AboutUs is not found in this Id");

        var asset = new AssetForCreationDto
        {
            FolderPath = "AboutUsAssets",
            FormFile = dto.Image
        };

        var assetPath = await _fileUploadService.FileUploadAsync(asset);

        var mappedEntity = _mapper.Map<AboutUsAsset>(dto);
        mappedEntity.Image = assetPath?.AssetPath;

        return _mapper.Map<AboutUsAssetForResultDto>(await _repository
            .CreateAsync(mappedEntity));
    }

    public async Task<IEnumerable<AboutUsAssetForResultDto>> GetAllAsync()
    {
        var entities = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AboutUsAssetForResultDto>>(entities);
    }

    public async Task<AboutUsAssetForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AbouteUsId == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(404, "aboutUsAsset is not found");

        var mappedEntity = _mapper.Map<AboutUsAssetForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<AboutUsAssetForResultDto> ModifyAsync(long id, AboutUsAssetForUpdateDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AbouteUsId == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "aboutUsAsset is not found");

        var mappedEntity = _mapper.Map(dto, entity);
        mappedEntity.UpdatedAt = DateTime.UtcNow;
        
        if (dto != null && dto.Image != null)
        {
            if (entity != null)
            {
                await _fileUploadService.DeleteFileAsync(entity.Image);
            }
            var asset = new AssetForCreationDto
            {
                FolderPath = "Sponsors",
                FormFile = dto.Image
            };

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mappedEntity.Image = assetPath?.AssetPath;

        }
        else
        {
            mappedEntity.Image = entity.Image;
        }

       // var result = await _repository.UpdateAsync(entity);

        var result = await _repository.UpdateAsync(mappedEntity);
        return _mapper.Map<AboutUsAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AbouteUsId == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "aboutUsAsset is not found");
        
        if (entity.Image != null)
            await _fileUploadService.DeleteFileAsync (entity.Image);

        return await _repository.DeleteAsync(id);
    }
}
