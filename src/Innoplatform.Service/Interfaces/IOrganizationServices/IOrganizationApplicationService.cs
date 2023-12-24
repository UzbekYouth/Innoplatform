using Innoplatform.Service.Configuration;
using Innoplatform.Service.DTOs.OrganizationApplications;
using Innoplatform.Service.DTOs.ProjectAssets;

namespace Innoplatform.Service.Interfaces.IOrganizationServices;

public interface IOrganizationApplicationService
{
    public Task<bool> RemoveAsync(long id);
    public Task<OrganizationApplicationForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<OrganizationApplicationForResultDto>> GetAllAsync(PaginationParams @params);
    public Task<OrganizationApplicationForResultDto> AddAsync(OrganizationApplicationForCreationDto dto);
    public Task<OrganizationApplicationForResultDto> ModifyAsync(long id, OrganizationApplicationForUpdateDto dto);
}
