using Innoplatform.Service.DTOs.OrganizationExtraDetails;
using Innoplatform.Service.DTOs.ProjectAssets;
using Innoplatform.Service.DTOs.Projects;

namespace Innoplatform.Service.Interfaces.IProjectServices;

public interface IProjectAssetService
{
    public Task<bool> RemoveAsync(long id);
    public Task<ProjectAssetForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<ProjectAssetForResultDto>> GetAllAsync();
    public Task<ProjectAssetForResultDto> AddAsync(ProjectAssetForCreationDto dto);
    public Task<ProjectAssetForResultDto> ModifyAsync(long id, ProjectAssetForUpdateDto dto);
}
