using Innoplatform.Service.DTOs.Sponsors;
using Innoplatform.Service.DTOs.Users;

namespace Innoplatform.Service.Interfaces.ISponsorServices;

public interface ISponsorService
{
    public Task<bool> RemoveAsync(long id);
    public Task<SponsorForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<SponsorForResultDto>> GetAllAsync();
    public Task<SponsorForResultDto> AddAsync(SponsorForCreationDto dto);
    public Task<SponsorForResultDto> ModifyAsync(long id, SponsorForUpdateDto dto);
}
