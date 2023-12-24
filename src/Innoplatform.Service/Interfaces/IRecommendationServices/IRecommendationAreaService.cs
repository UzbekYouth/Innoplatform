using Innoplatform.Service.DTOs.Projects;
using Innoplatform.Service.DTOs.RecommendationAreas;

namespace Innoplatform.Service.Interfaces;

public interface IRecommendationAreaService
{
    public Task<bool> RemoveAsync(long id);
    public Task<RecommendationAreaForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<RecommendationAreaForResultDto>> GetAllAsync();
    public Task<RecommendationAreaForResultDto> AddAsync(RecommendationAreaForCreationDto dto);
    public Task<RecommendationAreaForResultDto> ModifyAsync(long id, RecommendationAreaForUpdateDto dto);
}
