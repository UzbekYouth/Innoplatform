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
        Task<AchievmentForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<AchievmentForResultDto>> GetAllAsync();
        Task<AchievmentForResultDto> AddAsync(AchievmentForCreationDto dto);
        Task<AchievmentForResultDto> ModifyAsync(long id, AchievmentForUpdateDto dto);
    }
}
