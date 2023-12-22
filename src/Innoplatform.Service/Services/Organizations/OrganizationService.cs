using Innoplatform.Service.DTOs.Organizations;
using Innoplatform.Service.Interfaces;

namespace Innoplatform.Service.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        public Task<OrganizationForResultDto> AddAsync(OrganizationForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrganizationForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationForResultDto> ModifyAsync(long id, OrganizationForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
