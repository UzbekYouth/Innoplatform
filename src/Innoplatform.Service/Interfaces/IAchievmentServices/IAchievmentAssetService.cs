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
        Task<AchievmentAssetsForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<AchievmentAssetsForResultDto>> GetAllAsync();
        Task<AchievmentAssetsForResultDto> AddAsync(AchievmentAssetsForCreationDto dto);
        Task<AchievmentAssetsForResultDto> ModifyAsync(long id, AchievmentAssetsForUpdateDto dto);
    }
}
