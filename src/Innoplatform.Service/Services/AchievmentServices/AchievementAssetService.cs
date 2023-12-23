using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Achievments;
using Innoplatform.Service.DTOs.AchievementAssets;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces.IAchievmentServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.AchievmentServices;

public class AchievementAssetService : IAchievmentAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<AchievementAsset> _repository;

    public AchievementAssetService(IRepository<AchievementAsset> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AchievmentAssetsForResultDto> AddAsync(AchievmentAssetsForCreationDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AchievementId == dto.AchievementId)
            .FirstOrDefaultAsync();
        if (entity is not null)
            throw new InnoplatformException(404, "achievementAsset is already exist");

        var mappedEntity = _mapper.Map<AchievementAsset>(dto);

        var result = await _repository.CreateAsync(mappedEntity);

        return _mapper.Map<AchievmentAssetsForResultDto>(result);
    }

    public async Task<IEnumerable<AchievmentAssetsForResultDto>> GetAllAsync()
    {
        var entites = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AchievmentAssetsForResultDto>>(entites);
    }

    public async Task<AchievmentAssetsForResultDto> GetByIdAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AchievementId == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "achievementAsset is not found");

        var mappedEntity = _mapper.Map<AchievmentAssetsForResultDto>(entity);

        return mappedEntity;
    }

    public async Task<AchievmentAssetsForResultDto> ModifyAsync(long id, AchievmentAssetsForUpdateDto dto)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.AchievementId == id)
            .Where(e => e.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "achievementAsset is not found");

        var mappedEntity = _mapper.Map(dto, entity);
        mappedEntity.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mappedEntity);
        return _mapper.Map<AchievmentAssetsForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _repository.SelectAll()
            .Where(e => e.IsDeleted == false)
            .Where(e => e.AchievementId == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new InnoplatformException(400, "achievementAsset is not found");

        return await _repository.DeleteAsync(id);
    }
}
