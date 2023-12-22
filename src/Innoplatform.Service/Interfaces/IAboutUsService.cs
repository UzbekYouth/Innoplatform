
using Innoplatform.Service.DTOs.AboutUses;

namespace Innoplatform.Service.Interfaces
{
    public interface IAboutUsService
    {
        Task<bool> RemoveAsync(long id);
        Task<AboutUsResultDto> GetByIdAsync(long id);
        Task<IEnumerable<AboutUsResultDto>> GetAllAsync();
        Task<AboutUsResultDto> AddAsync(AboutUsForCreationDto dto);
        Task<AboutUsResultDto> ModifyAsync(long id, AboutUsForUpdateDto dto);
    }
}
