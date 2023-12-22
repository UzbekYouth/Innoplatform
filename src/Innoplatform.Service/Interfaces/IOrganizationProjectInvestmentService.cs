using Innoplatform.Service.DTOs.OrganizationProjectInvestments;

namespace Innoplatform.Service.Interfaces
{
    public interface IOrganizationProjectInvestmentService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<OrganizationProjectInvestmentForResultDto> GetByIdAsync(long id);
        public Task<IEnumerable<OrganizationProjectInvestmentForResultDto>> GetAllAsync();
        public Task<OrganizationProjectInvestmentForResultDto> AddAsync(OrganizationProjectInvestmentForCreationDto dto);
        public Task<OrganizationProjectInvestmentForResultDto> ModifyAsync(long id, OrganizationProjectInvestmentForUpdateDto dto);
    }
}
