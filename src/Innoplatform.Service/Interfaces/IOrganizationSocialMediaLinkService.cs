using Innoplatform.Service.DTOs.OrganizationSocialMediaLinks;

namespace Innoplatform.Service.Interfaces
{
    public interface IOrganizationSocialMediaLinkService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<OrganizationSocialMediaLinkForResultDto> GetByIdAsync(long id);
        public Task<IEnumerable<OrganizationSocialMediaLinkForResultDto>> GetAllAsync();
        public Task<OrganizationSocialMediaLinkForResultDto> AddAsync(OrganizationSocialMediaLinkForCreationDto dto);
        public Task<OrganizationSocialMediaLinkForResultDto> ModifyAsync(long id, OrganizationSocialMediaLinkForUpdateDto dto);
    }
}
