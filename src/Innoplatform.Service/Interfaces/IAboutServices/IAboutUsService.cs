using Innoplatform.Service.DTOs.AboutUses;

namespace Innoplatform.Service.Interfaces.IAboutServices
{
    public interface IAboutUsService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<AboutUsResultDto> GetByIdAsync(long id);
        public Task<IEnumerable<AboutUsResultDto>> GetAllAsync();
        public Task<AboutUsResultDto> AddAsync(AboutUsForCreationDto dto);
        public Task<AboutUsResultDto> ModifyAsync(long id, AboutUsForUpdateDto dto);
    }
}
