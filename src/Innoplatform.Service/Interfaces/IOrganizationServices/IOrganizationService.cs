using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.Organizations;

namespace Innoplatform.Service.Interfaces.IOrganizationServices
{
    public interface IOrganizationService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<OrganizationForResultDto> GetByIdAsync(long id);
        public Task<IEnumerable<OrganizationForResultDto>> GetAllAsync(PaginationParams @params);
        public Task<OrganizationForResultDto> AddAsync(OrganizationForCreationDto dto);
        public Task<OrganizationForResultDto> ModifyAsync(long id, OrganizationForUpdateDto dto);
    }
}
