using Innoplatform.Service.DTOs.OrganizationExtraDetails;
using Innoplatform.Service.DTOs.ProjectAssets;

namespace Innoplatform.Service.Interfaces;

public interface IOrganizationExtraDetailService
{
    public Task<bool> RemoveAsync(long id);
    public Task<OrganizationExtraDetailForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<OrganizationExtraDetailForResultDto>> GetAllAsync();
    public Task<OrganizationExtraDetailForResultDto> AddAsync(OrganizationExtraDetailForCreationDto dto);
    public Task<OrganizationExtraDetailForResultDto> ModifyAsync(long id, OrganizationExtraDetailForUpdateDto dto);
}
