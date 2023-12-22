using Innoplatform.Service.DTOs.AchievementAssets;
using Innoplatform.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services
{
    public class AchievementService : IAchievementService
    {
        public Task<AchievementForResultDto> AddAsync(AchievementForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AchievementForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AchievementForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<AchievementForResultDto> ModifyAsync(long id, AchievementForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
