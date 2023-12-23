using Innoplatform.Service.DTOs.AboutUses;
using Innoplatform.Service.DTOs.AchievementAssets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Interfaces.IAchievmentServices
{
    public interface IAchievmentAssetService
    {
        Task<bool> RemoveAsync(long id);
        Task<AchievementAssetsForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<AchievementAssetsForResultDto>> GetAllAsync();
        Task<AchievementAssetsForResultDto> AddAsync(AchievmentAssetsForCreationDto dto);
        Task<AchievementAssetsForResultDto> ModifyAsync(long id, AchievementAssetsForUpdateDto dto);
    }
}
