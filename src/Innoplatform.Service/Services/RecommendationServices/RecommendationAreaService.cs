using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Service.DTOs.RecommendationAreas;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.RecommendationServices;

public class RecommendationAreaService : IRecommendationAreaService
{
    private readonly IMapper _mapper;
    private readonly IRepository<RecommendationArea> _recommendationAreaRepository;

    public RecommendationAreaService(IMapper mapper, IRepository<RecommendationArea> recommendationAreaRepository)
    {
        _mapper = mapper;
        _recommendationAreaRepository = recommendationAreaRepository;
    }

    public async Task<RecommendationAreaForResultDto> AddAsync(RecommendationAreaForCreationDto dto)
    {
        var recommendationArea = await _recommendationAreaRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Area == dto.Area)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationArea is not null)
            throw new InnoplatformException(409, "Recommendation area is already exist");

        var mapped = _mapper.Map<RecommendationArea>(dto);

        var result = await _recommendationAreaRepository.CreateAsync(mapped);

        return _mapper.Map<RecommendationAreaForResultDto>(result);
    }

    public async Task<IEnumerable<RecommendationAreaForResultDto>> GetAllAsync()
    {
        var recommendationAreas = await _recommendationAreaRepository.SelectAll()
            .Where(r => r.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<RecommendationAreaForResultDto>>(recommendationAreas);
    }

    public async Task<RecommendationAreaForResultDto> GetByIdAsync(long id)
    {
        var recommendationArea = await _recommendationAreaRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationArea is null)
            throw new InnoplatformException(404, "Recommendation Area is not found");

        return _mapper.Map<RecommendationAreaForResultDto>(recommendationArea);
    }

    public async Task<RecommendationAreaForResultDto> ModifyAsync(long id, RecommendationAreaForUpdateDto dto)
    {
        var recommendationArea = await _recommendationAreaRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationArea is null)
            throw new InnoplatformException(404, "Recommendation Area is not found");

        var mapped = _mapper.Map(dto, recommendationArea);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _recommendationAreaRepository.UpdateAsync(mapped);

        return _mapper.Map<RecommendationAreaForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var recommendationArea = await _recommendationAreaRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationArea is null)
            throw new InnoplatformException(404, "Recommendation Area is not found");

        return await _recommendationAreaRepository.DeleteAsync(id)
    }
}
