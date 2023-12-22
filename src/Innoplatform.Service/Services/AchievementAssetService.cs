using Innoplatform.Service.DTOs.AchievementAssets;
using Innoplatform.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services
{
    public class AchievementAssetService : IAchievementAssetService
    {
        public Task<AchievementAssetsForResultDto> AddAsync(AchievementAssetsForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AchievementAssetsForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AchievementAssetsForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<AchievementAssetsForResultDto> ModifyAsync(long id, AchievementAssetsForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
