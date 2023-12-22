using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.DTOs.RecommendationAsset;

namespace Innoplatform.Service.Interfaces;

public interface IRecommendationAssetService
{
    public Task<bool> RemoveAsync(long id);
    public Task<RecommendationAssetForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<RecommendationAssetForResultDto>> GetAllAsync();
    public Task<RecommendationAssetForResultDto> AddAsync(RecommendationAssetForCreationDto dto);
    public Task<RecommendationAssetForResultDto> ModifyAsync(long id, RecommendationAssetForUpdateDto dto);
}
