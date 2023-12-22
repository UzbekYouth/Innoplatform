using Innoplatform.Service.DTOs.AboutUsAssets;
using Innoplatform.Service.DTOs.AboutUses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Interfaces
{
    public interface IAboutUsAssetService
    {
        Task<bool> RemoveAsync(long id);
        Task<AboutUsAssetForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<AboutUsAssetForResultDto>> GetAllAsync();
        Task<AboutUsAssetForResultDto> AddAsync(AboutUsAssetForCreationDto dto);
        Task<AboutUsAssetForResultDto> ModifyAsync(long id, AboutUsAssetForUpdateDto dto);
    }
}
