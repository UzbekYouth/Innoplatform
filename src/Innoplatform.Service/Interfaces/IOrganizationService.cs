using Innoplatform.Service.DTOs.Organizations;

namespace Innoplatform.Service.Interfaces
{
    public interface IOrganizationService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<OrganizationForResultDto> GetByIdAsync(long id);
        public Task<IEnumerable<OrganizationForResultDto>> GetAllAsync();
        public Task<OrganizationForResultDto> AddAsync(OrganizationForCreationDto dto);
        public Task<OrganizationForResultDto> ModifyAsync(long id, OrganizationForUpdateDto dto);
    }
}
