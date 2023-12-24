using AutoMapper;
using Innoplatform.Data.IRepositories;
using Innoplatform.Domain.Entities.Projects;
using Innoplatform.Domain.Entities.Recommendations;
using Innoplatform.Service.DTOs.Assets;
using Innoplatform.Service.DTOs.RecommendationAsset;
using Innoplatform.Service.Exceptions;
using Innoplatform.Service.Interfaces;
using Innoplatform.Service.Interfaces.IFileUploadServices;
using Microsoft.EntityFrameworkCore;

namespace Innoplatform.Service.Services.RecommendationServices;

public class RecommendationAssetService : IRecommendationAssetService
{
    private readonly IMapper _mapper;
    private readonly IFileUploadService _fileUploadService;
    private readonly IRepository<Recommendation> _recommendationRepository;
    private readonly IRepository<RecommendationAsset> _recommendationAssetRepository;

    public RecommendationAssetService(
        IMapper mapper,
        IFileUploadService fileUploadService,
        IRepository<Recommendation> recommendationRepository,
        IRepository<RecommendationAsset> recommendationAssetRepository)
    {
        _mapper = mapper;
        _fileUploadService = fileUploadService;
        _recommendationRepository = recommendationRepository;
        _recommendationAssetRepository = recommendationAssetRepository;
    }

    // addAsync method fix error



    public async Task<RecommendationAssetForResultDto> AddAsync(RecommendationAssetForCreationDto dto)
    {
        var recommendation = await _recommendationRepository.SelectAll()
            .Where(r => r.IsDeleted == false && r.Id == dto.RecommendationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (recommendation is null)
            throw new InnoplatformException(404, "Recommendation is not found");

        var asset = new AssetForCreationDto
        {
            FolderPath = "RecommendationAssets",
            FormFile = dto.Media
        };

        if (asset.FormFile.ContentType != "image/jpeg" && asset.FormFile.ContentType != "image/png" && asset.FormFile.ContentType != "image/jpg" && asset.FormFile.ContentType != "image/HEIC" && asset.FormFile.ContentType != "video/mp4")
        {
            throw new InnoplatformException(400, "Media is not valid");
        }

        var assetPath = await _fileUploadService.FileUploadAsync(asset);

        var mapped = _mapper.Map<RecommendationAsset>(dto);
        mapped.Media = assetPath?.AssetPath;

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

        if (dto != null && dto.Media != null)
        {
            if (recommendationAsset != null)
            {
                await _fileUploadService.DeleteFileAsync(recommendationAsset.Media);
            }
            var asset = new AssetForCreationDto
            {
                FolderPath = "Recommendations",
                FormFile = dto.Media
            };

            if (asset.FormFile.ContentType != "image/jpeg" && asset.FormFile.ContentType != "image/png" && asset.FormFile.ContentType != "image/jpg" && asset.FormFile.ContentType != "image/HEIC" && asset.FormFile.ContentType != "video/mp4")
            {
                throw new InnoplatformException(400, "Image is not valid");
            }

            var assetPath = await _fileUploadService.FileUploadAsync(asset);
            mapped.Media = assetPath?.AssetPath;

        }
        else
        {
            mapped.Media = mapped.Media;
        }


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

        if(recommendationAsset.Media != null)
        {
            await _fileUploadService.DeleteFileAsync(recommendationAsset.Media);
        }

        return await _recommendationAssetRepository.DeleteAsync(id);
    }
}
