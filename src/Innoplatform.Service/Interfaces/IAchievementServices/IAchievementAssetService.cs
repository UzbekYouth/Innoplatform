using Innoplatform.Service.DTOs.AchievementAssets;

namespace Innoplatform.Service.Interfaces.IAchievmentServices;

public interface IAchievementAssetService
{
    Task<bool> RemoveAsync(long id);
    Task<AchievementAssetsForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<AchievementAssetsForResultDto>> GetAllAsync();
    Task<AchievementAssetsForResultDto> AddAsync(AchievmentAssetsForCreationDto dto);
    Task<AchievementAssetsForResultDto> ModifyAsync(long id, AchievementAssetsForUpdateDto dto);
}
