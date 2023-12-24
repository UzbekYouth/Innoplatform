using Innoplatform.Service.DTOs.OrganizationInvestmentInvitations;
using Innoplatform.Service.DTOs.ProjectAssets;

namespace Innoplatform.Service.Interfaces.IOrganizationServices;

public interface IOrganizationInvestmentInvitationService
{
    public Task<bool> RemoveAsync(long id);
    public Task<OrganizationInvestmentInvitationForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<OrganizationInvestmentInvitationForResultDto>> GetAllAsync();
    public Task<OrganizationInvestmentInvitationForResultDto> AddAsync(OrganizationInvestmentInvitationForCreationDto dto);
}
