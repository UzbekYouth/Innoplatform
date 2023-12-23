using Innoplatform.Service.DTOs.Educations;
using Innoplatform.Service.DTOs.ProjectAssets;

namespace Innoplatform.Service.Interfaces.IEducationServices;

public interface IEducationService
{
    public Task<bool> RemoveAsync(long id);
    public Task<EducationForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<EducationForResultDto>> GetAllAsync();
    public Task<EducationForResultDto> AddAsync(EducationForCreationDto dto);
    public Task<EducationForResultDto> ModifyAsync(long id, EducationForUpdateDto dto);
}
