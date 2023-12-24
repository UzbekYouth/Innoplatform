using Innoplatform.Service.DTOs.ProjectInvestmentInvitations;

namespace Innoplatform.Service.Interfaces.IProjectServices
{
    public interface IProjectInvestmentInvitationService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<ProjectInvestmentInvitationForResultDto> GetByIdAsync(long id);
        public Task<IEnumerable<ProjectInvestmentInvitationForResultDto>> GetAllAsync();
        public Task<ProjectInvestmentInvitationForResultDto> AddAsync(ProjectInvestmentInvitationForCreationDto dto);
        public Task<ProjectInvestmentInvitationForResultDto> ModifyAsync(long id, ProjectInvestmentInvitationForUpdateDto dto);
    }
}
