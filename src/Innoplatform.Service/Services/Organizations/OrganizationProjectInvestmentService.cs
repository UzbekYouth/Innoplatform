using Innoplatform.Service.DTOs.OrganizationInvestment;
using Innoplatform.Service.Interfaces;

namespace Innoplatform.Service.Services.Organizations
{
    public class OrganizationProjectInvestmentService : IOrganizationInvestmentService
    {
        public Task<OrganizationInvestmentForResultDto> AddAsync(OrganizationInvestmentForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrganizationInvestmentForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationInvestmentForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationInvestmentForResultDto> ModifyAsync(long id, OrganizationInvestmentForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
