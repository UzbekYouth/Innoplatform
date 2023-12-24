using Innoplatform.Service.DTOs.AboutUses;

namespace Innoplatform.Service.Interfaces.IAboutServices
{
    public interface IAboutUsService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<AboutUsForResultDto> GetByIdAsync(long id);
        public Task<IEnumerable<AboutUsForResultDto>> GetAllAsync();
        public Task<AboutUsForResultDto> AddAsync(AboutUsForCreationDto dto);
        public Task<AboutUsForResultDto> ModifyAsync(long id, AboutUsForUpdateDto dto);
    }
}
