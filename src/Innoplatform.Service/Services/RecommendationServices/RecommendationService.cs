using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.Recommendations;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.RecommendationServices;
public class RecommendationService : IRecommendationService
{
    private readonly IMapper _mapper;
    private readonly IFileUploadService _fileUploadService;
    private readonly IRepository<Recommendation> _recommendationRepository;
    private readonly IRepository<RecommendationArea> _recommendationAreaRepository;

    public RecommendationService(
            IMapper mapper,
            IFileUploadService fileUploadService,
            IRepository<Recommendation> recommendationRepository,
            IRepository<RecommendationArea> recommendationAreaRepository)
    {
        _mapper = mapper;
        _fileUploadService = fileUploadService;
        _recommendationRepository = recommendationRepository;
        _recommendationAreaRepository = recommendationAreaRepository;
    }
    public async Task<RecommendationForResultDto> AddAsync(RecommendationForCreationDto dto)
    {
        var recommendationArea = await _recommendationAreaRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == dto.RecommendationAreaId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendationArea is null)
            throw new InnoplatformException(404, "Recommendation area not found");

        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Title.ToLower() == dto.Title.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendation is not null)
            throw new InnoplatformException(409, "Recommendation  already exist");

        var asset = new AssetForCreationDto
        {
            FolderPath = "Recommendations",
            FormFile = dto.Image
        };

        var assetPath = await _fileUploadService.FileUploadAsync(asset);

        var mappedRecommendation = _mapper.Map<Recommendation>(dto);
        mappedRecommendation.Image = assetPath?.AssetPath;


        var createdRecommendation = await _recommendationRepository.CreateAsync(mappedRecommendation);

        return _mapper.Map<RecommendationForResultDto>(createdRecommendation);
    }

    public async Task<IEnumerable<RecommendationForResultDto>> GetAllAsync()
    {
        var recommendations = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false)
            .Include(r => r.RecommendationArea)
            .Include(a => a.RecommendationAssets)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<RecommendationForResultDto>>(recommendations);
    }

    public async Task<RecommendationForResultDto> GetByIdAsync(long id)
    {
        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .Include(r => r.RecommendationArea)
            .Include(a => a.RecommendationAssets)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendation is null)
            throw new InnoplatformException(404, "Recommendation not found");

        return _mapper.Map<RecommendationForResultDto>(recommendation);
    }

    public async Task<RecommendationForResultDto> ModifyAsync(long id, RecommendationForUpdateDto dto)
    {
        var recommendationArea = await _recommendationAreaRepository.SelectAll()
           .Where(r => r.IsDeleted == false && r.Id == dto.RecommendationAreaId)
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

        if (dto != null && dto.Image != null)
        {
            if (recommendation != null)
            {
                await _fileUploadService.DeleteFileAsync(recommendation.Image);
            }
            var asset = new AssetForCreationDto
            {
                FolderPath = "Sponsors",
                FormFile = dto.Image
            };

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mapped.Image = assetPath?.AssetPath;

        }
        else
        {
            mapped.Image = mapped.Image;
        }

        var updatedRecommendation = await _recommendationRepository.UpdateAsync(mapped);

        return _mapper.Map<RecommendationForResultDto>(updatedRecommendation);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == id)
            .Include(r => r.RecommendationAssets)
            .FirstOrDefaultAsync();

        if (recommendation is null)
            throw new InnoplatformException(404, "Recommendation not found");

        if(recommendation.Image != null)
        {
            await _fileUploadService.DeleteFileAsync(recommendation.Image);
        }

        foreach (var relatedEntity in recommendation.RecommendationAssets)
        {
            if(relatedEntity.Media != null)
            {
                relatedEntity.IsDeleted = true;
            }
        }
        return await _recommendationRepository.DeleteAsync(id);
    }
}

