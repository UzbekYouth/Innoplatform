using Innoplatform.Service.DTOs.AchievementAssets;

namespace Innoplatform.Service.Interfaces.IAchievmentServices;

public interface IAchievementService
{
    Task<bool> RemoveAsync(long id);
    Task<AchievementForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<AchievementForResultDto>> GetAllAsync();
    Task<AchievementForResultDto> AddAsync(AchievementForCreationDto dto);
    Task<AchievementForResultDto> ModifyAsync(long id, AchievementForUpdateDto dto);
}
