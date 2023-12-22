using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Service.DTOs.RecommendationAsset;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.RecommendationServices;

public class RecommendationAssetService : IRecommendationAssetService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Recommendation> _recommendationRepository;
    private readonly IRepository<RecommendationAsset> _recommendationAssetRepository;

    public RecommendationAssetService(
        IMapper mapper,
        IRepository<Recommendation> recommendationRepository,
        IRepository<RecommendationAsset> recommendationAssetRepository)
    {
        
    }
    public async Task<RecommendationAssetForResultDto> AddAsync(RecommendationAssetForCreationDto dto)
    {
        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == dto.RecommendationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendation is null)
            throw new InnoplatformException(404, "Recommendation is not found");

        var recommendationAsset = await _recommendationAssetRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.RecommendationId == dto.RecommendationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationAsset is not null)
            throw new InnoplatformException(409, "Recommendation asset is already exist");

        var mapped = _mapper.Map<RecommendationAsset>(dto);

        var result = await _recommendationAssetRepository.CreateAsync(mapped);

        return _mapper.Map<RecommendationAssetForResultDto>(result);
    }

    public async Task<IEnumerable<RecommendationAssetForResultDto>> GetAllAsync()
    {
        var recommendationAssets = await _recommendationAssetRepository.SelectAll()
            .Where(r => r.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<RecommendationAssetForResultDto>>(recommendationAssets);
    }

    public async Task<RecommendationAssetForResultDto> GetByIdAsync(long id)
    {
        var recommendationAsset = await _recommendationAssetRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationAsset is null)
            throw new InnoplatformException(404, "Recommendation Asset is not found");

        return _mapper.Map<RecommendationAssetForResultDto>(recommendationAsset);
    }

    public async Task<RecommendationAssetForResultDto> ModifyAsync(long id, RecommendationAssetForUpdateDto dto)
    {
        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == dto.RecommendationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendation is null)
            throw new InnoplatformException(404, "Recommendation is not found");

        var recommendationAsset = await _recommendationAssetRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationAsset is null)
            throw new InnoplatformException(404, "Recommendation Asset is not found");

        var mapped = _mapper.Map(dto, recommendationAsset);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _recommendationAssetRepository.UpdateAsync(mapped);

        return _mapper.Map<RecommendationAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var recommendationAsset = await _recommendationAssetRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationAsset is null)
            throw new InnoplatformException(404, "Recommendation Asset is not found");

        return await _recommendationAssetRepository.DeleteAsync(id);
    }
}
