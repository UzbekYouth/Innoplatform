using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Service.DTOs.Recommendations;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.RecommendationServices;
public class RecommendationService : IRecommendationService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Recommendation> _recommendationRepository;
    private readonly IRepository<RecommendationArea> _recommendationAreaRepository;

    public RecommendationService(
            IMapper mapper,
            IRepository<Recommendation> recommendationRepository,
            IRepository<RecommendationArea> recommendationAreaRepository)
    {
        _mapper = mapper;
        _recommendationRepository = recommendationRepository;
        _recommendationAreaRepository = recommendationAreaRepository;
    }
    public async Task<RecommendationForResultDto> AddAsync(RecommendationForCreationDto dto)
    {
        var recommendationArea = await _recommendationAreaRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == dto.RecomedationAreaId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationArea is null)
            throw new InnoplatformException(404, "Recommendation area not found");

        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.RecomedationAreaId == dto.RecomedationAreaId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendation is not null)
            throw new InnoplatformException(409, "Recommendation area already has a recommendation");

        var mappedRecommendation = _mapper.Map<Recommendation>(dto);

        var createdRecommendation = await _recommendationRepository.CreateAsync(mappedRecommendation);

        return _mapper.Map<RecommendationForResultDto>(createdRecommendation);
    }

    public async Task<IEnumerable<RecommendationForResultDto>> GetAllAsync()
    {
        var recommendations = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<RecommendationForResultDto>>(recommendations);
    }

    public async Task<RecommendationForResultDto> GetByIdAsync(long id)
    {
        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendation is null)
            throw new InnoplatformException(404, "Recommendation not found");

        return _mapper.Map<RecommendationForResultDto>(recommendation);
    }

    public async Task<RecommendationForResultDto> ModifyAsync(long id, RecommendationForUpdateDto dto)
    {
        var recommendationArea = await _recommendationAreaRepository.SelectAll()
           .Where(r => r.IsDeleted == false && r.Id == dto.RecomedationAreaId)
           .AsNoTracking()
           .FirstOrDefaultAsync();

        if (recommendationArea is null)
            throw new InnoplatformException(404, "Recommendation area not found");

        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendation is null)
            throw new InnoplatformException(404, "Recommendation not found");

        var mapped = _mapper.Map(dto, recommendation);
        mapped.UpdatedAt = DateTime.UtcNow;

        var updatedRecommendation = await _recommendationRepository.UpdateAsync(mapped);

        return _mapper.Map<RecommendationForResultDto>(updatedRecommendation);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .FirstOrDefaultAsync();

        if (recommendation is null)
            throw new InnoplatformException(404, "Recommendation not found");

        return await _recommendationRepository.DeleteAsync(id);
    }
}

