using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Achievments;
using Innoplatform.Domain.Entities.Sponsors;
using Innoplatform.Service.DTOs.AchievementAssets;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Innoplatform.Service.Interfaces.IAchievmentServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.AchievmentServices;

public class AchievementAssetService : IAchievementAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<AchievementAsset> _repository;
    private readonly IRepository<Achievement> _achievementRepository;
    private readonly IFileUploadService _fileUploadService;

    public AchievementAssetService(
        IRepository<AchievementAsset> repository,
        IMapper mapper,
        IFileUploadService fileUploadService,
        IRepository<Achievement> achievementRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _fileUploadService = fileUploadService;
        _achievementRepository = achievementRepository;
    }

    public async Task<AchievementAssetsForResultDto> AddAsync(AchievmentAssetsForCreationDto dto)
    {
        var existAchievement = await _achievementRepository.SelectAll()
            .Where(ea => ea.Id == dto.AchievementId && ea.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existAchievement is null)
            throw new InnoplatformException(400, "Achievement is not found in this Id");

        var asset = new AssetForCreationDto
        {
            FolderPath = "AchievementAsset",
            FormFile = dto.Media
        };

        var assetPath = await _fileUploadService.FileUploadAsync(asset);

        var mapped = _mapper.Map<AchievementAsset>(dto);
        mapped.Media = assetPath?.AssetPath;

        var result = await _repository.CreateAsync(mapped);

        return _mapper.Map<AchievementAssetsForResultDto>(result);
    }

    public async Task<IEnumerable<AchievementAssetsForResultDto>> GetAllAsync()
    {
        var entites = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<AchievementAssetsForResultDto>>(entites);
    }

    public async Task<AchievementAssetsForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "achievementAsset is not found");

        var mappedEntity = _mapper.Map<AchievementAssetsForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<AchievementAssetsForResultDto> ModifyAsync(long id, AchievementAssetsForUpdateDto dto)
    {
        var existAchievement = await _achievementRepository.SelectAll()
            .Where(ea => ea.Id == dto.AchievementId && ea.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existAchievement is null)
            throw new InnoplatformException(400, "Achievement is not found in this Id");

        var entity = await _repository.SelectAll()
            .Where(e => e.AchievementId == dto.AchievementId)
            .Where(e => e.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "achievementAsset is not found");

        var mappedEntity = _mapper.Map(dto, entity);
        mappedEntity.UpdatedAt = DateTime.UtcNow;

        if (dto != null && dto.Media != null)
        {
            if (entity != null)
            {
                await _fileUploadService.DeleteFileAsync(entity.Media);
            }
            var asset = new AssetForCreationDto
            {
                FolderPath = "Sponsors",
                FormFile = dto.Media
            };

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mappedEntity.Media = assetPath?.AssetPath;

        }
        else
        {
            mappedEntity.Media = mappedEntity.Media;
        }

        var result = await _repository.UpdateAsync(mappedEntity);
        return _mapper.Map<AchievementAssetsForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false && e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "achievementAsset is not found");

        if (entity.Media != null)
        {
            await _fileUploadService.DeleteFileAsync(entity.Media);
        }

        return await _repository.DeleteAsync(id);
    }
}
