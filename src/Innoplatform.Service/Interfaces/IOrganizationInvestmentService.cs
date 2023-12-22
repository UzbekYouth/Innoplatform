using Innoplatform.Service.DTOs.OrganizationInvestment;

namespace Innoplatform.Service.Interfaces
{
    public interface IOrganizationInvestmentService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<OrganizationInvestmentForResultDto> GetByIdAsync(long id);
        public Task<IEnumerable<OrganizationInvestmentForResultDto>> GetAllAsync();
        public Task<OrganizationInvestmentForResultDto> AddAsync(OrganizationInvestmentForCreationDto dto);
        public Task<OrganizationInvestmentForResultDto> ModifyAsync(long id, OrganizationInvestmentForUpdateDto dto);
    }
}
