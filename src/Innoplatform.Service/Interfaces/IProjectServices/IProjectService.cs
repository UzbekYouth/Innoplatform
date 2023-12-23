using Innoplatform.Service.DTOs.InvestmentAreas;
using Innoplatform.Service.DTOs.Projects;

namespace Innoplatform.Service.Interfaces.IProjectServices;

public interface IProjectService
{
    public Task<bool> RemoveAsync(long id);
    public Task<ProjectForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<ProjectForResultDto>> GetAllAsync();
    public Task<ProjectForResultDto> AddAsync(ProjectForCreationDto dto);
    public Task<ProjectForResultDto> ModifyAsync(long id, ProjectForUpdateDto dto);
}
