using Innoplatform.Service.DTOs.ProjectInvestments;
using Innoplatform.Service.DTOs.Projects;

namespace Innoplatform.Service.Interfaces;

public interface IProjectInvestmentService
{
    public Task<bool> RemoveAsync(long id);
    public Task<ProjectInvestmentForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<ProjectInvestmentForResultDto>> GetAllAsync();
    public Task<ProjectInvestmentForResultDto> AddAsync(ProjectInvestmentForCreationDto dto);
    public Task<ProjectInvestmentForResultDto> ModifyAsync(long id, ProjectInvestmentForUpdateDto dto);
}
