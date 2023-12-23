using Innoplatform.Service.DTOs.AboutUses;
using Innoplatform.Service.DTOs.AchievementAssets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Interfaces.IAchievmentServices
{
    public interface IAchievmentService
    {
        Task<bool> RemoveAsync(long id);
        Task<AchievementForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<AchievementForResultDto>> GetAllAsync();
        Task<AchievementForResultDto> AddAsync(AchievementForCreationDto dto);
        Task<AchievementForResultDto> ModifyAsync(long id, AchievementForUpdateDto dto);
    }
}
