using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.AboutUses;
using Innoplatform.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services
{
    public class AboutUsAssetService : IAboutUsAssetService
    {
        public Task<AboutUsAssetForResultDto> AddAsync(AboutUsAssetForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AboutUsAssetForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AboutUsAssetForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<AboutUsAssetForResultDto> ModifyAsync(long id, AboutUsAssetForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
