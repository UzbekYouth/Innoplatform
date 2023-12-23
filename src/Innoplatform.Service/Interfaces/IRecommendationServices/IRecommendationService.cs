using Innoplatform.Service.DTOs.Recommendations;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces;

public interface IRecommendationService
{
    public Task<bool> RemoveAsync(long id);
    public Task<RecommendationForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<RecommendationForResultDto>> GetAllAsync();
    public Task<RecommendationForResultDto> AddAsync(RecommendationForCreationDto dto);
    public Task<RecommendationForResultDto> ModifyAsync(long id, RecommendationForUpdateDto dto);
}
